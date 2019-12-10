using System.Text.Json.Serialization;

namespace Task12.Models
{
    internal sealed class CurrencyItem
    {
        [JsonPropertyName("currencyId")]
        public string CurrencyId { get; set; }

        [JsonPropertyName("currencyName")]
        public string CurrencyName { get; set; }

        public override string ToString()
        {
            return $"{CurrencyId} ({CurrencyName})";
        }
    }
}
