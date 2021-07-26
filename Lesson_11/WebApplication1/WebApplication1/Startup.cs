using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = new PathString("/Auth/Login");
                });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Basic authentication
            //app.Use(async (ctx, next) =>
            //{
            //    StringValues value = string.Empty;
            //    if (ctx.Request.Headers.TryGetValue("Authorization", out value))
            //    {
            //        string base64 = value.ToString().Split(" ")[1];
            //        byte[] base64EncodedBytes = Convert.FromBase64String(base64);
            //        string data = Encoding.UTF8.GetString(base64EncodedBytes);

            //        string login = data.Split(":")[0];
            //        string password = data.Split(":")[1];

            //        if (login.Equals("admin") && password.Equals("admin"))
            //        {
            //            await next.Invoke();
            //        }
            //        else
            //        {
            //            ctx.Response.StatusCode = 401;  // 401 - Unauthorized
            //            ctx.Response.Headers.Add("WWW-Authenticate", "Basic realm='Unauthorized'");
            //        }
            //    }
            //    else
            //    {
            //        ctx.Response.StatusCode = 401;  // 401 - Unauthorized
            //        ctx.Response.Headers.Add("WWW-Authenticate", "Basic realm='Unauthorized'");
            //    }
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
