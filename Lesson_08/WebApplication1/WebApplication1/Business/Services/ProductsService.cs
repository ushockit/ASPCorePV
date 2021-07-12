using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business.DTO;
using WebApplication1.DB.Repositories;

namespace WebApplication1.Business.Services
{
    public class ProductsService : IProductsService
    {
        IUnitOfWork uow;
        public ProductsService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public Task CreateNewProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await uow.ProductsRepository.GetAllAsync();
            return products.Select(prod => new ProductDTO
            {
                Id = prod.Id,
                Name = prod.Name,
                Price = prod.Price
            }).ToList();
        }

        public Task<ProductDTO> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
