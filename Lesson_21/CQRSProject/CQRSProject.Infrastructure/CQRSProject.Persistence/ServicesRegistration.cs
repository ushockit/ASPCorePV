using System;
using CQRSProject.Domain.Repositories;
using CQRSProject.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
