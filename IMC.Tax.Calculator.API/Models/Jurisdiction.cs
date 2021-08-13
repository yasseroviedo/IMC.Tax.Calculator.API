using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMC.Tax.Calculator.API.Models
{
    public class Jurisdiction
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string State { get; set; }
    }
}
