using IMC.TaxCalcutalor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMC.Tax.Calculator.API.Models
{
    public class Tax
    {
        public float AmountToCollect { get; set; }
        public Breakdown Breakdown { get; set; }
        public bool FreightTaxable { get; set; }
        public bool HasNexus { get; set; }
        public Jurisdiction jurisdiction { get; set; }
        public float OrderTotalAmount { get; set; }
        public float Rate { get; set; }
        public float Shipping { get; set; }
        public string TaxSource { get; set; }
        public float TaxableAmount { get; set; }
    }
}
