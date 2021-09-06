using System;
using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Domain.Entities;

namespace CQRSProject.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public IRepository<int, Product> ProductsRepository { get; }
    }
}
