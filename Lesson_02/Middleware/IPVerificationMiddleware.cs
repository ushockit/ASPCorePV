using System;
using System.Threading.Tasks;
using Lesson_02.Business.Implementation;
using Microsoft.AspNetCore.Http;

namespace Lesson_02.Middleware
{
    public class IPVerificationMiddleware
    {
        private readonly RequestDelegate _next;
        public IPVerificationMiddleware(RequestDelegate next, ImageUploadService imageUploadService)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string userIp = context.Connection.RemoteIpAddress.ToString();
            context.Items.Add("ip", userIp);
            await context.Response.WriteAsync($"IP = {userIp}");
            await _next.Invoke(context);
        }
    }
}
