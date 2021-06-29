using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_01.Middleware
{
    public class EmailVerificationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> _availableEmailAddresses;
        public EmailVerificationMiddleware(RequestDelegate next, List<string> availableEmailAddresses)
        {
            _next = next;
            _availableEmailAddresses = availableEmailAddresses;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string email = context.Request.Query["email"].ToString();
            if (string.IsNullOrWhiteSpace(email) || !_availableEmailAddresses.Contains(email))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid email");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
