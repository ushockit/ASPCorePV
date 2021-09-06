using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Domain.Entities;

namespace CQRSProject.Domain.Repositories
{
    public interface IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TValue> GetAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TValue> Create(TValue entity);
        void Remove(TKey id);
        void Update(TValue entity);
    }
}
