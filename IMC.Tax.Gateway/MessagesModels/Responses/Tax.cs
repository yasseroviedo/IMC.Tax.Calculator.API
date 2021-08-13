using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMC.Tax.Gateway.MessagesModels.Responses
{

    public class RootTax
    {
        [JsonPropertyName("tax")]
        public Tax tax { get; set; }
    }

    public class Tax
    {
        [JsonPropertyName("amount_to_collect")]
        public float Amount_To_Collect { get; set; }
        [JsonPropertyName("breakdown")]
        public Breakdown Breakdown { get; set; }
        [JsonPropertyName("freight_taxable")]
        public bool Freight_Taxable { get; set; }
        [JsonPropertyName("has_nexus")]
        public bool Has_Nexus { get; set; }
        [JsonPropertyName("jurisdictions")]
        public Jurisdictions Jurisdictions { get; set; }
        [JsonPropertyName("order_total_amount")]
        public float Order_Total_Amount { get; set; }
        [JsonPropertyName("rate")]
        public float Rate { get; set; }
        [JsonPropertyName("shipping")]
        public float Shipping { get; set; }
        [JsonPropertyName("tax_source")]
        public string Tax_Source { get; set; }
        [JsonPropertyName("taxable_amount")]
        public float Taxable_Amount { get; set; }
    }

    public class Breakdown
    {
        [JsonPropertyName("city_tax_collectable")]
        public float City_Tax_Collectable { get; set; }
        [JsonPropertyName("city_tax_rate")]
        public float City_Tax_Rate { get; set; }
        [JsonPropertyName("city_taxable_amount")]
        public float City_Taxable_Amount { get; set; }
        [JsonPropertyName("combined_tax_rate")]
        public float Combined_Tax_Rate { get; set; }
        [JsonPropertyName("county_tax_collectable")]
        public float County_Tax_Collectable { get; set; }
        [JsonPropertyName("county_tax_rate")]
        public float County_Tax_Rate { get; set; }
        [JsonPropertyName("county_taxable_amount")]
        public float County_Taxable_Amount { get; set; }
        [JsonPropertyName("line_items")]
        public Line_Items[] Line_Items { get; set; }
        [JsonPropertyName("shipping")]
        public Shipping Shipping { get; set; }
        [JsonPropertyName("special_district_tax_collectable")]
        public float Special_District_Tax_Collectable { get; set; }
        [JsonPropertyName("special_district_taxable_amount")]
        public float Special_District_Taxable_Amount { get; set; }
        [JsonPropertyName("special_tax_rate")]
        public float Special_Tax_Rate { get; set; }
        [JsonPropertyName("state_tax_collectable")]
        public float State_Tax_Collectable { get; set; }
        [JsonPropertyName("state_tax_rate")]
        public float State_Tax_Rate { get; set; }
        [JsonPropertyName("state_taxable_amount")]
        public float State_Taxable_Amount { get; set; }
        [JsonPropertyName("tax_collectable")]
        public float Tax_Collectable { get; set; }
        [JsonPropertyName("taxable_amount")]
        public float Taxable_Amount { get; set; }
    }

    public class Shipping
    {
        [JsonPropertyName("city_amount")]
        public float City_Amount { get; set; }
        [JsonPropertyName("city_tax_rate")]
        public float City_Tax_Rate { get; set; }
        [JsonPropertyName("city_taxable_amount")]
        public float City_Taxable_Amount { get; set; }
        [JsonPropertyName("combined_tax_rate")]
        public float Combined_Tax_Rate { get; set; }
        [JsonPropertyName("county_amount")]
        public float County_Amount { get; set; }
        [JsonPropertyName("county_tax_rate")]
        public float County_Tax_Rate { get; set; }
        [JsonPropertyName("county_taxable_amount")]
        public float County_Taxable_Amount { get; set; }
        [JsonPropertyName("special_district_amount")]
        public float Special_District_Amount { get; set; }
        [JsonPropertyName("special_tax_rate")]
        public float Special_Tax_Rate { get; set; }
        [JsonPropertyName("special_taxable_amount")]
        public float Special_Taxable_Amount { get; set; }
        [JsonPropertyName("state_amount")]
        public float State_Amount { get; set; }
        [JsonPropertyName("state_sales_tax_rate")]
        public float State_Sales_Tax_Rate { get; set; }
        [JsonPropertyName("state_taxable_amount")]
        public float State_Taxable_Amount { get; set; }
        [JsonPropertyName("tax_collectable")]
        public float Tax_Collectable { get; set; }
        [JsonPropertyName("taxable_amount")]
        public float Taxable_Amount { get; set; }
    }

    public class Line_Items
    {
        [JsonPropertyName("city_amount")]
        public float City_Amount { get; set; }
        [JsonPropertyName("city_tax_rate")]
        public float City_Tax_Rate { get; set; }
        [JsonPropertyName("city_taxable_amount")]
        public float City_Taxable_Amount { get; set; }
        [JsonPropertyName("combined_tax_rate")]
        public float Combined_Tax_Rate { get; set; }
        [JsonPropertyName("county_amount")]
        public float County_Amount { get; set; }
        [JsonPropertyName("county_tax_rate")]
        public float County_Tax_Rate { get; set; }
        [JsonPropertyName("county_taxable_amount")]
        public float County_Taxable_Amount { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("special_district_amount")]
        public float Special_District_Amount { get; set; }
        [JsonPropertyName("special_district_taxable_amount")]
        public float Special_District_Taxable_Amount { get; set; }
        [JsonPropertyName("special_tax_rate")]
        public float Special_Tax_Rate { get; set; }
        [JsonPropertyName("state_amount")]
        public float State_Amount { get; set; }
        [JsonPropertyName("state_sales_tax_rate")]
        public float State_Sales_Tax_Rate { get; set; }
        [JsonPropertyName("state_taxable_amount")]
        public float State_Taxable_Amount { get; set; }
        [JsonPropertyName("tax_collectable")]
        public float Tax_Collectable { get; set; }
        [JsonPropertyName("taxable_amount")]
        public float Taxable_Amount { get; set; }
    }

    public class Jurisdictions
    {
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("county")]
        public string County { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
    }

}
