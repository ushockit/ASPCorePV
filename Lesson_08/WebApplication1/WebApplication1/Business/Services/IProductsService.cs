using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business.DTO;

namespace WebApplication1.Business.Services
{
    public interface IProductsService
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task CreateNewProduct(ProductDTO product);
    }
}
