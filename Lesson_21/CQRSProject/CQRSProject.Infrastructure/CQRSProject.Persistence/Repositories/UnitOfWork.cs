using System;
using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Repositories;
using CQRSProject.Persistence.Context;

namespace CQRSProject.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext db;
        readonly Lazy<IRepository<int, Product>> _productsRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
            _productsRepository = new Lazy<IRepository<int, Product>>(() => new ProductsRepository(context));
        }

        public IRepository<int, Product> ProductsRepository => _productsRepository.Value;
    }
}
