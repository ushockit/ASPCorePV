using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSProject.Application.Feautures.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQueryRequest());
            return View(products);
        }
    }
}
