using System;
using System.Net;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.GlobalExceptions
{
    public class GlobalException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public GlobalException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
