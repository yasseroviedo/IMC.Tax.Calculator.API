using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IMC.Tax.Gateway.MessagesModels.Requests
{
    public class LineItemRequest
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit_price")]
        public double Unit_Price { get; set; }

        [JsonProperty("product_tax_code")]
        public string Product_Tax_Code { get; set; }
    }
}
