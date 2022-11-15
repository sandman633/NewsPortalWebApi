using DAL.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NewsPortal.WebApi.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsPortal.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (AuthentificationException ex)
            {
                await HandleException(ex, ex.StatusCode, httpContext);
            }
            catch (Exception e)
            {
                await HandleException(e, 500, httpContext);
            }
        }
        private async Task HandleException(Exception e, int statusCode, HttpContext httpContext)
        {
            _logger.LogError(e.Message + $"\r\n{e.StackTrace}");
            httpContext.Response.ContentType = "application/json";

            Result result;
            GenerateResultOnException(e, statusCode, out result);

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.WriteAsJsonAsync(JsonSerializer.Serialize(result));
        }
        private void GenerateResultOnException(Exception exception, int statusCode, out Result result)
        {
            if (exception is AuthentificationException authentificationException)
            {
                var listErrors = new List<Error>() { new Error() { ErrorMessage = authentificationException.Message, ErrorCode = authentificationException.StatusCode, Description = authentificationException.Description } };
                result = new Result(statusCode, listErrors);
                return;
            }
            result = new Result(statusCode);
        }
    }
}
