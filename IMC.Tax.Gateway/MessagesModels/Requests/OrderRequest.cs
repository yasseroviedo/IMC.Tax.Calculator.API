using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IMC.Tax.Gateway.MessagesModels.Requests
{
    public class OrderRequest
    {
        [JsonProperty("from_country")]
        public string From_Country { get; set; }

        [JsonProperty("from_zip")]
        public string From_Zip { get; set; }

        [JsonProperty("from_state")]
        public string From_State { get; set; }

        [JsonProperty("to_country")]
        public string To_Country { get; set; }

        [JsonProperty("to_zip")]
        public string To_Zip { get; set; }

        [JsonProperty("to_state")]
        public string To_State { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        [JsonProperty("line_items")]
        public List<LineItemRequest> Line_Items { get; set; }
    }


}