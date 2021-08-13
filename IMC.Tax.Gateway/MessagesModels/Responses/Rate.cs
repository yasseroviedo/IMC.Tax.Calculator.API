using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMC.Tax.Gateway.MessagesModels.Responses
{

    public class RootRate
    {
        public Rate rate { get; set; }
    }

    public class Rate
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("city_rate")]
        public string City_Rate { get; set; }

        [JsonPropertyName("combined_district_rate")]
        public string Combined_District_Rate { get; set; }

        [JsonPropertyName("combined_rate")]
        public string Combined_Rate { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_rate")]
        public string Country_Rate { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("county_rate")]
        public string County_Rate { get; set; }

        [JsonPropertyName("freight_taxable")]
        public bool Freight_Taxable { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("state_rate")]
        public string State_Rate { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }

}
