using System;
using CQRSProject.Domain.Entities;
using CQRSProject.Persistence.Context;

namespace CQRSProject.Persistence.Repositories
{
    public class ProductsRepository : BaseRepository<int, Product>
    {
        public ProductsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
