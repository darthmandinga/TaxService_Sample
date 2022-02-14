using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaxService_Sample.TaxServices
{
    internal class TaxJarRate
    {
        [JsonPropertyName("rate")]
        public TaxJarRateProperties RateProps { get; set; }

        internal class TaxJarRateProperties
        {
            [JsonPropertyName("zip")]
            public string Zip { get; set; }
            [JsonPropertyName("country")]
            public string Country { get; set; }
            [JsonPropertyName("country_rate")]
            public string CountryRate { get; set; }
            [JsonPropertyName("state")]
            public string State { get; set; }
            [JsonPropertyName("state_rate")]
            public string StateRate { get; set; }
            [JsonPropertyName("county")]
            public string County { get; set; }
            [JsonPropertyName("county_rate")]
            public string CountyRate { get; set; }
            [JsonPropertyName("city")]
            public string City { get; set; }
            [JsonPropertyName("city_rate")]
            public string CityRate { get; set; }
            [JsonPropertyName("combined_district_rate")]
            public string CombinedDistrictRate { get; set; }
            [JsonPropertyName("combined_rate")]
            public string CombinedRate { get; set; }
            [JsonPropertyName("freight_taxable")]
            public bool FreightTaxable { get; set; }
        }

        /// <summary>
        /// Deserializes a JSON string into a TaxJarRate object
        /// </summary>
        /// <param name="json">The JSON to deserialize</param>
        /// <returns>The Hydrated TaxJarRate Object</returns>
        public static TaxJarRate Deserialize(string json)
        {            
            return JsonSerializer.Deserialize<TaxJarRate>(json);
        }
    }
}
