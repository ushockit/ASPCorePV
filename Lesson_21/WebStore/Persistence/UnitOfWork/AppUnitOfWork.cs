using Domain.Entities;
using Domain.Interfaces;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class AppUnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext db;
        readonly Lazy<IRepository<int, Product>> _productsRepository;
        public IRepository<int, Product> ProductsRepository => _productsRepository.Value;

        public AppUnitOfWork(ApplicationDbContext context)
        {
            db = context;
            _productsRepository = new Lazy<IRepository<int, Product>>(() => new ProductsRepository(context));
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return db.SaveChangesAsync();
        }
    }
}
