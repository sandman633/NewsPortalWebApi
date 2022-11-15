using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DAL.Response
{
    public class Result<T> : Result
    {
        public Result(T data,int statusCode=200) : base(statusCode)
        {
            Data = data;
        }

        public Result(int statusCode, List<Error>? errors) : base(statusCode, errors)
        {
        }
        public T Data { get; set; }
    }
    public class Result
    {
        public Result(int statusCode)
        {
            StatusCode = statusCode;
        }
        public Result(int statusCode, List<Error>? errors) : this(statusCode)
        {
            Errors = errors;
        }
        public int StatusCode { get; init; }
        public List<Error>? Errors { get; init; }
    }
    public class Error
    {
        public string ErrorMessage { get; init; }
        public string? Description { get; init; }
        public int ErrorCode { get; init; }
    }
}
