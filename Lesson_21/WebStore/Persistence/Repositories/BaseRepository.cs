using Domain.Common;
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
    internal abstract class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected ApplicationDbContext db;
        protected DbSet<TValue> Table => db.Set<TValue>();

        public BaseRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public abstract Task<TValue> CreateAsync(TValue entity);

        public abstract Task<TValue> GetAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<IEnumerable<TValue>> GetAllAsync(CancellationToken cancellationToken = default);

        public abstract void Remove(TKey id);

        public abstract void Update(TValue entity);
    }
}
