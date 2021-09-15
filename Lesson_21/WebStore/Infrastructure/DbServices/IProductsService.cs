using Infrastructure.Dtos.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DbServices
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductDTO> CreateAsync(CreateProductDTO product, CancellationToken cancellationToken = default);
    }
}
