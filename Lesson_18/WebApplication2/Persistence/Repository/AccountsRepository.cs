using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Persistence.Repository
{
    internal sealed class AccountsRepository : BaseRepository<Guid, Account>

    {
        public AccountsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Account> Create(Account entity)
        {
            await db.Accounts.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public override async Task<IEnumerable<Account>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await db.Accounts.Include(account => account.Todos).ToListAsync();
        }

        public override Task<Account> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
