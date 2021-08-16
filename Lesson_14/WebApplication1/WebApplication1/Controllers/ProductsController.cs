using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            var user = User;
            return new JsonResult(new object());
        }
    }
}
