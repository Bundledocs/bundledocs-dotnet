namespace Bundledocs.Api.Wrapper.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// Represents an error returned by the Bundledocs API.
    /// Contains the HTTP status code and response body for diagnostic purposes.
    /// </summary>
    public class BundledocsApiException : Exception
    {
        public BundledocsApiException(string message, HttpStatusCode statusCode, string responseContent)
            : base(message)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        public BundledocsApiException(string message, HttpStatusCode statusCode, string responseContent, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        public HttpStatusCode StatusCode { get; }

        public string ResponseContent { get; }
    }
}
