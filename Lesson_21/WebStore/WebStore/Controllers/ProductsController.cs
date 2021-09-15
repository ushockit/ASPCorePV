using Application.Features.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
    public class ProductsController : Controller
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllProductsQueryRequest request)
        {
            var products = await _mediator.Send(request);
            return View();
        }
    }
}
