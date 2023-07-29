using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Exceptions
{
    public class eCommerceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public eCommerceException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
