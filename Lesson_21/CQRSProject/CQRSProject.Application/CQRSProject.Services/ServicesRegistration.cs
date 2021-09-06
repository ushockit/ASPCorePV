using System;
using CQRSProject.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSProject.Services
{
    public static class ServicesRegistration
    {
        public static void AddDbServices(this IServiceCollection services)
        {
            services.AddSingleton<IServiceManager, ServiceManager>();
        }
    }
}
