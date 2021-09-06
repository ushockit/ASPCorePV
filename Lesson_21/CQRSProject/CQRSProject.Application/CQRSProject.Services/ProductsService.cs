using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Application.Dtos.Products;
using CQRSProject.Application.Interfaces;
using CQRSProject.Domain.Repositories;

namespace CQRSProject.Services
{
    public class ProductsService : IProductsService
    {
        readonly IUnitOfWork _unitOfWork;
        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ProductDto> CreateAsync(CreateProductDto model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
