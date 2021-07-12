using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DB.Entities;

namespace WebApplication1.DB.Repositories
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
