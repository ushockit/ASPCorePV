using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Utils;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly AppUtils utils;

        public HomeController(ILogger<HomeController> logger, AppUtils utils)
        {
            _logger = logger;
            this.utils = utils;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCulture(string culture)
        {
            if (!utils.AvailableCultures.Any(c => c.Name.Equals(culture)))
            {
                return BadRequest("Culture doesnt` exists");
            }
            HttpContext.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMonths(1)
                });
            return Json("Ok");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
