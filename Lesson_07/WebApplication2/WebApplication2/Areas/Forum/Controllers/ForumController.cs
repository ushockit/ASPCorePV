using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.Forum.Controllers
{
    [Area("Forum")]
    [Route("forum")]
    public class ForumController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
