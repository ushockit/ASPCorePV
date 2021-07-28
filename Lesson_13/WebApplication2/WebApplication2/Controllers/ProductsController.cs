using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO.Products;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<ProductDTO> products = new List<ProductDTO>();

        static ProductsController()
        {
            for (int i = 0; i < 10; i++)
            {
                products.Add(new ProductDTO
                {
                    Id = i + 1,
                    Name = $"Product {i + 1}",
                    Price = 100 + i
                });
            }
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return products;
        }

        [HttpGet("productsInRange")]
        public IEnumerable<ProductDTO> GetProductsInPriceRange([FromQuery]ProductsInRangeDTO range)
        {
            return products.Where(p => p.Price >= range.From && p.Price <= range.To);
        }


        [HttpPost] 
        public ProductDTO Create(ProductDTO product)
        {
            product.Id = products.Count > 0 ? products.Last().Id + 1 : 1;
            products.Add(product);
            return product;
        }

        [HttpPut]
        public ActionResult Update(ProductDTO product)
        {
            var srchProduct = products.FirstOrDefault(p => p.Id == product.Id);

            if (srchProduct is null)
            {
                return BadRequest("Product was not found");
            }

            srchProduct.Name = product.Name;
            srchProduct.Price = product.Price;

            return new JsonResult(srchProduct);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var srchProduct = products.FirstOrDefault(p => p.Id == id);
            if (srchProduct is null)
            {
                return BadRequest("Product was not found");
            }
            products.Remove(srchProduct);
            return new JsonResult(new 
            {
                Message = "Success",
                Code = 200
            });
        }
    }
}
