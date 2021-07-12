using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DB.Entities;

namespace WebApplication1.DB.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DatabaseContext db;

        DbSet<T> Table => db.Set<T>();

        public BaseRepository(DatabaseContext context)
        {
            db = context;
        }
        public async Task CreateAsync(T entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(Table.ToList());
        }

        public async Task<T> GetAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
