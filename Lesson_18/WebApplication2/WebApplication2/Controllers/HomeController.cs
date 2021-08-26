using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions.Service;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly IServiceManager serviceManager;
        public HomeController(ILogger<HomeController> logger, IServiceManager serviceManager)
        {
            _logger = logger;
            this.serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var todos = (await serviceManager.ToDosService.GetAllAsync()).ToList();
            return View();
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
