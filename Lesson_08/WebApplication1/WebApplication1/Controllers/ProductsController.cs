using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business.Services;
using WebApplication1.Models.Products;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        IProductsService productsService;
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productsService.GetAllProducts();
            return View(new ProductsIndexViewModel
            {
                Products = products.Select(prod => new ProductViewModel
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Price = prod.Price
                }).ToList()
            });
        }
    }
}
