using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMC.Tax.Calculator.API.Models
{
    public class OrderLineItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string ProductTaxCode { get; set; }
    }
}
