using System;

namespace NewsPortal.WebApi.Infrastructure.Exceptions
{
    public class AuthentificationException : Exception
    {
        public AuthentificationException(int statusCode, string messageText, string description, Exception innerException) : base(messageText, innerException)
        {
            StatusCode = statusCode;
            Description = description;
        }
        public AuthentificationException(int statusCode, string messageText, string description) : base(messageText)
        {
            Description = description;
            StatusCode = statusCode;
        }
        public AuthentificationException(int statusCode, string messageText) : base(messageText)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; }

        public string Description { get; }
    }
}
