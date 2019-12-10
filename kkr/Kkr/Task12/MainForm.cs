using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task12.Models;
using Task12.Services;

namespace Task12
{
    public sealed partial class MainForm : Form
    {
        private readonly ICurrencyConverterService _currencyConverter = new CurrConvApiService();
        private readonly IProgress<int> _loadingProgress;

        public MainForm()
        {
            InitializeComponent();
            _loadingProgress = new Progress<int>(value => loadingStatus.Value = value);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                return await _currencyConverter.ListCurrenciesAsync(_loadingProgress, default);
            }).ContinueWith(task =>
            {
                listFrom.DataSource = listTo.DataSource = task.Result;

                if (task.Result.Count == 0)
                {
                    MessageBox.Show("Unable to load the list of currencies from remote API server.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    listFrom.Enabled = listTo.Enabled = true;
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFrom.SelectedItem is null || listTo.SelectedItem is null)
                return;

            string from = (listFrom.SelectedItem as CurrencyItem).CurrencyId,
                    to = (listTo.SelectedItem as CurrencyItem).CurrencyId;

            Task.Run(async () =>
            {
                var fromTo = await _currencyConverter.ConvertAsync(from, to, _loadingProgress, default);
                var toFrom = await _currencyConverter.ConvertAsync(to, from, _loadingProgress, default);

                return (fromTo, toFrom);
            }).ContinueWith(t =>
            {
                var (fromTo, toFrom) = t.Result;
                if (fromTo == null || toFrom == null)
                    return;

                labelResult1.Text = $"1 {fromTo.From} = {fromTo.Value} {fromTo.To}";
                labelResult2.Text = $"1 {toFrom.From} = {toFrom.Value} {toFrom.To}";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
