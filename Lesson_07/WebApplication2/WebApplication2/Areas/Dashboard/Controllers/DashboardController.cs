using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Route("dashboard")]
    public class DashboardController : Controller
    {
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }
        [Route("info")]
        public IActionResult Info()
        {
            return View();
        }   
    }
}
