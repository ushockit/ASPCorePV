using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                // BadRequestException => StatusCodes.Status400BadRequest,
                // NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            var response = new
            {
                error = exception.Message,
                statusCode = httpContext.Response.StatusCode
            };
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
