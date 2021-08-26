using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;
        readonly Lazy<IRepository<Guid, ToDoItem>> _todosRepository;
        readonly Lazy<IRepository<Guid, Account>> _accountsRepository;
        public IRepository<Guid, ToDoItem> ToDosRepository => _todosRepository.Value;
        public IRepository<Guid, Account> AccountsRepository => _accountsRepository.Value;


        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
            _todosRepository = new Lazy<IRepository<Guid, ToDoItem>>(() => new ToDosRepository(context));
            _accountsRepository = new Lazy<IRepository<Guid, Account>>(() => new AccountsRepository(context));
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return db.SaveChangesAsync();
        }
    }
}
