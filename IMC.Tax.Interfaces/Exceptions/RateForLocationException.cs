using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IMC.Tax.Interfaces.Exceptions
{
    public class RateForLocationException : HttpRequestException
    {
        public RateForLocationException()
        {
        }

        public RateForLocationException(string message)
            : base(message)
        {
        }

        public RateForLocationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RateForLocationException(string message, Exception inner, HttpStatusCode? statusCode) : base(message, inner, statusCode)
        {
        }
    }
}
