using Application.Features.Commands.CreateProduct;
using Application.Features.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllProductsQueryResponse>> GetProducts()
        {
            return await _mediator.Send(new GetAllProductsQueryRequest());
        }

        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateNewProduct([FromBody]CreateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
