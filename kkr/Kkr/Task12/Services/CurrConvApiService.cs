using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Task12.Models;

namespace Task12.Services
{
    internal sealed class CurrConvApiService : ICurrencyConverterService
    {
        private List<CurrencyItem> _currencyItems;
        private readonly ConcurrentDictionary<string, ConvertedCurrency> _cachedConvertedCurrencies = new ConcurrentDictionary<string, ConvertedCurrency>(2, 10);
        private readonly SemaphoreSlim _listCurrenciesBlocker = new SemaphoreSlim(1, 1);
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://free.currconv.com/api/v7/")
        };

        private const string ApiKey = "36aa5f091ff20d27a16f"; // 183615e1b9c729e8ac6e

        public async ValueTask<ConvertedCurrency> ConvertAsync(string from, string to, IProgress<int> progress, CancellationToken ct)
        {
            if (_cachedConvertedCurrencies.TryGetValue($"{from}_{to}", out var value))
                return value;

            progress.Report(2);
            using var response = await _client.GetAsync($"convert?q={from}_{to},{to}_{from}&compact=ultra&apiKey={ApiKey}", ct);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                progress.Report(0);
                return null;
            }

            progress.Report(4);
            var jsonStream = await response.Content.ReadAsStreamAsync();

            progress.Report(6);
            using var jsonDocument = await JsonDocument.ParseAsync(jsonStream, cancellationToken: ct);

            progress.Report(8);
            foreach (var jsonObject in jsonDocument.RootElement.EnumerateObject())
            {
                if (!jsonObject.Value.TryGetDecimal(out var convertedValue))
                    continue;

                var separated = jsonObject.Name.Split('_');
                var convertedCurrency = new ConvertedCurrency
                {
                    From = separated[0],
                    To = separated[1],
                    Value = convertedValue
                };
                _cachedConvertedCurrencies.TryAdd(jsonObject.Name, convertedCurrency);

                if (convertedCurrency.From == from && convertedCurrency.To == to)
                    value = convertedCurrency;
            }

            progress.Report(0);
            return value;
        }

        public async ValueTask<IReadOnlyCollection<CurrencyItem>> ListCurrenciesAsync(IProgress<int> progress, CancellationToken ct)
        {
            await _listCurrenciesBlocker.WaitAsync(TimeSpan.FromSeconds(10d), ct);

            try
            {
                if (_currencyItems != null)
                    return _currencyItems;

                progress.Report(3);

                using var response = await _client.GetAsync("countries?apiKey=" + ApiKey, ct);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    progress.Report(0);
                    return new List<CurrencyItem>(0);
                }

                progress.Report(6);
                var jsonStream = await response.Content.ReadAsStreamAsync();
                progress.Report(8);
                _currencyItems = await JsonSerializer.DeserializeAsync<List<CurrencyItem>>(jsonStream, null, ct);

                progress.Report(0);
                return _currencyItems;
            }
            finally
            {
                _listCurrenciesBlocker.Release();
            }
        }
    }
}
