using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRSProject.Application.Interfaces;
using MediatR;

namespace CQRSProject.Application.Feautures.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler
        : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        readonly IServiceManager _serviceManager;
        readonly IMapper _mapper;

        public GetAllProductsQueryHandler(
            IServiceManager serviceManager,
            IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productsList = await _serviceManager.ProductsService.GetAllAsync();
            return _mapper.Map<List<GetAllProductsQueryResponse>>(productsList);
        }
    }
}
