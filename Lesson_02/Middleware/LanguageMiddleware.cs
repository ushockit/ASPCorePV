using System;
using System.Threading.Tasks;
using Lesson_02.Services;
using Microsoft.AspNetCore.Http;

namespace Lesson_02.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ISettingsService settingsService)
        {
            // Получение куки из запроса
            string lang = context.Request.Cookies["lang"];
            if (lang is null)
            {
                context.Response.Cookies.Append("lang", settingsService.DefaultLanguage.ToString().ToLower(), new CookieOptions
                {
                    Expires = new DateTimeOffset(new DateTime(2030, 1, 1))
                });
            }
            await context.Response.WriteAsync("Hello");
            //await _next.Invoke(context);
        }
    }
}
