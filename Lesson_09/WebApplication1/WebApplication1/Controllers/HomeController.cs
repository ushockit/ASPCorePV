using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var categories = new CategoryViewModel[]
                {
                    new CategoryViewModel { Id = 1, Name = "Category 1" },
                    new CategoryViewModel { Id = 2, Name = "Category 2" },
                    new CategoryViewModel { Id = 3, Name = "Category 3" },
                };
            var viewModel = new IndexViewModel
            {
                GenderValues = Enum.GetNames(typeof(Gender)),
                CategoriesForDropDown = new SelectList(categories, "Id", "Name"),
                CategoriesForListBox = new MultiSelectList(categories, "Id", "Name"),
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string firstName, string gender, int categoryId, int[] categoryIds)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
