using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Application.Dtos.Products;

namespace CQRSProject.Application.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductDto> CreateAsync(CreateProductDto model, CancellationToken cancellationToken = default);
    }
}
