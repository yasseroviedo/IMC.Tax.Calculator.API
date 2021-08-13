using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IMC.Tax.Interfaces.Exceptions
{
    public class TaxesException: HttpRequestException
    {
        public TaxesException()
        {
        }

        public TaxesException(string message)
            : base(message)
        {
        }

        public TaxesException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public TaxesException(string message, Exception inner, HttpStatusCode? statusCode) : base(message, inner, statusCode)
        {
        }
    }
}
