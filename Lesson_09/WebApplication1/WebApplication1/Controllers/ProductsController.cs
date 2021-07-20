using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewProduct(CreateNewProductViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}
