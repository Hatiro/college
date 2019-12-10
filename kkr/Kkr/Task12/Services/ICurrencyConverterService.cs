using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Task12.Models;

namespace Task12.Services
{
    internal interface ICurrencyConverterService
    {
        ValueTask<ConvertedCurrency> ConvertAsync(string from, string to, IProgress<int> progress, CancellationToken ct);

        ValueTask<IReadOnlyCollection<CurrencyItem>> ListCurrenciesAsync(IProgress<int> progress, CancellationToken ct);
    }
}
