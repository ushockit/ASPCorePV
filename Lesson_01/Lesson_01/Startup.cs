using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson_01.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lesson_01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // env.IsEnvironment("Development")
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.Use(async (context, next) =>
            //{
            //    var email = context.Request.Query["email"].ToString();

            //    if (string.IsNullOrWhiteSpace(email))
            //    {
            //        context.Response.StatusCode = 400;
            //        await context.Response.WriteAsync("Email doesn`t exists");
            //    }
            //    else
            //    {
            //        await context.Response.WriteAsync("<h1>Middleware response</h1>");
            //        // передача запроса дальше по цепочке
            //        await next.Invoke();
            //    }
            //});

            app.UseMiddleware<IPVerificationMiddleware>(new List<string> { "::1" });
            app.UseMiddleware<EmailVerificationMiddleware>(new List<string> { "vasya@gmail.com" });

            app.Map("/about", (about) =>
            {
                about.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>About page</h1>");
                });
            });
            app.Map("/home", Home);

            // переход к конечной точке по условию
            //app.MapWhen((context) => context.Request.Query.ContainsKey("email"), (_app) =>
            //{
            //    _app.Run(async (context) => 
            //    {
            //        await context.Response.WriteAsync("Hello");
            //    });
            //});

            app.UseEndpoints(endpoints =>
            {
                int value = 0;
                endpoints.MapGet("/", async context =>
                {
                    //value++;
                    //await context.Response.WriteAsync($"Value = {value}");
                    //value++;
                    string email = context.Request.Query["email"].ToString();
                    await context.Response.WriteAsync($"Hi, {email}!");
                });
            });
        }
        public static void Home(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1>Home page</h1>");
            });
        }
    }
}
