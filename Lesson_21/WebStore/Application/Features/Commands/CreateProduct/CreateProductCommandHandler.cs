using AutoMapper;
using Infrastructure.DbServices;
using Infrastructure.Dtos.ProductDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IServiceManager _serviceManager;
        readonly IMapper _mapper;
        public CreateProductCommandHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var prod = _mapper.Map<CreateProductDTO>(request);
            var product = await _serviceManager.ProductsService.CreateAsync(prod);

            return _mapper.Map<CreateProductCommandResponse>(product);
        }
    }
}
