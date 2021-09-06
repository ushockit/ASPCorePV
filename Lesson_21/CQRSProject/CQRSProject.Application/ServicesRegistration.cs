using System;
using System.Reflection;
using CQRSProject.Application.Interfaces;
using CQRSProject.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSProject.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IServiceManager, ServiceManager>();
        }
    }
}
