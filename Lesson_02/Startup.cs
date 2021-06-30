using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson_02.Business.Implementation;
using Lesson_02.Business.Interfaces;
using Lesson_02.Middleware;
using Lesson_02.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lesson_02
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Регистрация сервиса
            services.AddSingleton<FileUploadService>();
            services.AddSingleton<ImageUploadService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddDistributedMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FileUploadService uploadService, ISettingsService settingsService)
        {

            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseMiddleware<IPVerificationMiddleware>();
            app.UseMiddleware<LanguageMiddleware>();
            app.UseRouting();

            app.Map("/index", (home) =>
            {
                home.Run(async (context) =>
                {
                    // обработка POST запроса
                    if (context.Request.Method == "POST")
                    {
                        string inputValue = context.Request.Form["inputValue"].ToString();
                        ;
                    }
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("<form method='post'><input name='inputValue'><button>Send</button></form>");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // if (!context.Session.Keys.Contains("lang"))
                    // {
                    //    context.Session.SetString("lang", "ru");
                    //}
                    string ip = context.Items["ip"] as string;
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("Hello world");
                });
            });
        }
    }
}
