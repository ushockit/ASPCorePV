using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }
        public IActionResult About()
        {
            ViewData["title"] = "About";
            return View();
        }
        public IActionResult Contacts()
        {
            ViewData["title"] = "Contacts";
            return View();
        }
    }
}
