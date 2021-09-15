using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>>
    {
        public int Limit { get; set; }
    }
}
