using System;
using CQRSProject.Application.Interfaces;
using CQRSProject.Domain.Repositories;

namespace CQRSProject.Services
{
    public class ServiceManager : IServiceManager
    {
        readonly Lazy<IProductsService> _productsService;

        public IProductsService ProductsService => _productsService.Value;
        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _productsService = new Lazy<IProductsService>(() => new ProductsService(unitOfWork));
        }
    }
}
