using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbServices
{
    internal sealed class ServiceManager : IServiceManager
    {
        readonly Lazy<IProductsService> _productsService;
        public IProductsService ProductsService => _productsService.Value;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productsService = new Lazy<IProductsService>(() => new ProductsService(unitOfWork, mapper));
        }
    }
}
