using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Storage;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        UsersStorage _usersStorage;
        public HomeController(UsersStorage usersStorage) 
        {
            _usersStorage = usersStorage;
        }

        public IActionResult Index(/*[FromServices] UsersStorage usersStorage*/)
        {
            // var usersStorage = HttpContext.RequestServices.GetService(typeof(UsersStorage));
            return View(new HomeIndexViewModel 
            { 
                People = _usersStorage.People
            });
        }

        [HttpPost]
        public IActionResult DisablePerson(int? id, string disabled)
        {
            if (id is null)
            {
                return BadRequest();
            }
            if (disabled.Equals("on"))
            {
                _usersStorage.DisablePerson((int)id);
            }
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
