using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Home;
using WebApplication1.Validators;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateElement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateElement(CreateElementViewModel model)
        {
            var validators = new IModelPropertyValidator[]
            {
                new DescriptionDoesNotExistsInModelValidator(model.Description)
            };

            // Какой-то валидатор не отработал
            if (!validators.Any(validator => validator.Validate()))
            {
                ModelState.AddModelError("CustomError", "Что-то пошло не так");
            }

            // Добавление кастомной валидации
            if (model.Name != null && !Regex.IsMatch(model.Name, "^[A-ZА-Я]"))
            {
                ModelState.AddModelError("Name", "Имя должно начинаться с большой буквы");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
