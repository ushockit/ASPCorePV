using AutoMapper;
using Infrastructure.DbServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler 
        : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        readonly IServiceManager _serviceManager;
        readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _serviceManager.ProductsService.GetAllAsync();
            return _mapper.Map<List<GetAllProductsQueryResponse>>(products);
        }
    }
}
