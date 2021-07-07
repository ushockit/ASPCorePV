using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using WebApplication1.Models.Products;
using WebApplication1.Services;
using WebApplication1.Storage;
using WebApplication1.Storage.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        TempDB _tempDB;
        ISessionService _sessionService;
        public ProductsController(TempDB tempDB, ISessionService sessionService)
        {
            _tempDB = tempDB;
            _sessionService = sessionService;
        }
        public IActionResult Index()
        {
            return View(new ProductsIndexViewModel 
            { 
                Products = _tempDB.Products.Select(prod => new ProductViewModel 
                { 
                    Id = prod.Id,
                    Title = prod.Title,
                    Description = prod.Description,
                    Price = prod.Price,
                    Category = new CategoryViewModel
                    {
                        Id = _tempDB.Categories.First(category => category.Id == prod.CategoryId).Id,
                        Name = _tempDB.Categories.First(category => category.Id == prod.CategoryId).Name
                    }
                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            Product product = _tempDB.Products.FirstOrDefault(product => product.Id == (int)id);

            if (product is null)
            {
                return NotFound($"Product not found");
            }

            _sessionService.AddProductToCart(HttpContext, "cart", new ProductViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Category = new CategoryViewModel
                {
                    Id = _tempDB.Categories.First(category => category.Id == product.CategoryId).Id,
                    Name = _tempDB.Categories.First(category => category.Id == product.CategoryId).Name
                }
            });
            StringValues referer;
            HttpContext.Request.Headers.TryGetValue("referer", out referer);
            return Redirect(referer.First());
        }
    }
}
