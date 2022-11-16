using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsPortal.Repositories.Infrastructure.Exceptions
{
    public class DataTransactionException : Exception
    {
        public new string Data { get; set; }
        public int StatusCode { get; set; }
        public DataTransactionException(string message, object data, int statusCode) : base(message)
        {
            Data = JsonSerializer.Serialize(data);
            StatusCode = statusCode;
        }

        public DataTransactionException(string message, string data, int statusCode, Exception innerException) : base(message, innerException)
        {
            Data = JsonSerializer.Serialize(data);
        }

        
    }
}
