using Domain.Entity;
using Domain.Repository;
using Services.Abstractions.Dto.ToDoItem;
using Services.Abstractions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class ToDosService : IToDosService
    {
        private readonly IUnitOfWork unitOfWork;

        public ToDosService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Task<ToDoItemDto> CreateAsync(CreateToDoItemDto model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var todos = await unitOfWork.ToDosRepository.GetAllAsync(cancellationToken);
            return todos.Select(todo => new ToDoItemDto
            {
                Id = todo.Id,
                Completed = todo.Completed,
                CreatedAt = todo.CreatedAt,
                Discription = todo.Discription,
                Title = todo.Title
            });
        }

        public Task<IEnumerable<ToDoItemDto>> GetAllCompletedTodos(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateToDoItemDto model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
