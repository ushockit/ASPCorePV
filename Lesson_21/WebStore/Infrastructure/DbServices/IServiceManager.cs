using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbServices
{
    public interface IServiceManager
    {
        IProductsService ProductsService { get; }
    }
}
