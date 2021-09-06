using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Repositories;
using CQRSProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Persistence.Repositories
{
    public class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected readonly ApplicationDbContext db;
        private DbSet<TValue> Table { get => db.Set<TValue>(); }
        public BaseRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public Task<TValue> Create(TValue entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TValue>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TValue> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Update(TValue entity)
        {
            throw new NotImplementedException();
        }
    }
}
