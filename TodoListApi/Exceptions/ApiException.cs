using System;
using System.Net;

public class HttpStatusCodeException : Exception
{
    public HttpStatusCode StatusCode { get; private set; }

    public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}