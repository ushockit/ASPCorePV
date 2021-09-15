using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TKey, TValue>
       where TKey : struct
       where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TValue> GetAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TValue> CreateAsync(TValue entity);
        void Remove(TKey id);
        void Update(TValue entity);
    }
}
