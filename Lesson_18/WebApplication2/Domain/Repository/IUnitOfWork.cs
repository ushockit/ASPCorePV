using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        public IRepository<Guid, ToDoItem> ToDosRepository { get; }
        public IRepository<Guid, Account> AccountsRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
