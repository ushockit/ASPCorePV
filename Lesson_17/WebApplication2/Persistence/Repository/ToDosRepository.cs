using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    internal sealed class ToDosRepository : BaseRepository<Guid, ToDoItem>
    {
        public ToDosRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<ToDoItem> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await db.ToDos.FirstOrDefaultAsync(todo => todo.Id == id);
        }

        public override void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(ToDoItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
