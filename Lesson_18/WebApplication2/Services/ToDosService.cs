using Domain.Entity;
using Domain.Repository;
using Services.Abstractions.Dto.Account;
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

        public async Task<ToDoItemDto> CreateAsync(CreateToDoItemDto model, CancellationToken cancellationToken = default)
        {
            var newTodo = await unitOfWork.ToDosRepository.Create(new ToDoItem
            {
                Title = model.Title,
                Description = model.Description,
                Completed = model.Completed,
                AccountId = model.AccountId
            });
            return new ToDoItemDto
            {
                Id = newTodo.Id,
                Title = newTodo.Title,
                Description = newTodo.Description,
                Completed = newTodo.Completed,
                CreatedAt = newTodo.CreatedAt,
                AccountId = newTodo.AccountId,
            };
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
                Description = todo.Description,
                Title = todo.Title,
                AccountId = todo.AccountId,
            });
        }

        public Task<IEnumerable<ToDoItemDto>> GetAllCompletedTodos(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todo = await unitOfWork.ToDosRepository.GetAsync(id, cancellationToken);
            return new ToDoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Completed = todo.Completed,
                CreatedAt = todo.CreatedAt,
                AccountId = todo.AccountId,
                Account = new AccountDto
                {
                    Id = todo.Account.Id,
                    Email = todo.Account.Email,
                    Confirmed = todo.Account.Confirmed,
                    CreatedAt = todo.Account.CreatedAt,
                    Password = todo.Account.Password
                }
            };
        }

        public Task UpdateAsync(UpdateToDoItemDto model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
