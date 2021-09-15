using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class ProductsRepository : BaseRepository<int, Product>
    {
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Product> CreateAsync(Product entity)
        {
            Table.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public override async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Table.ToListAsync();
        }

        public override Task<Product> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
