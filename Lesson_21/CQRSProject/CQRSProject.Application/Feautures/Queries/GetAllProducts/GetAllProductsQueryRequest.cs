using System;
using System.Collections.Generic;
using MediatR;

namespace CQRSProject.Application.Feautures.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>>
    {

    }
}
