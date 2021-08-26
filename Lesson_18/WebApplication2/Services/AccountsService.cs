using Domain.Repository;
using Services.Abstractions.Dto.Account;
using Services.Abstractions.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Services.Abstractions.Dto.ToDoItem;

namespace Services
{
    internal sealed class AccountsService : IAccountsService
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountsService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public async Task<AccountDto> CreateAsync(CreateAccountDto model, CancellationToken cancellationToken = default)
        {
            var account = await unitOfWork.AccountsRepository.Create(new Domain.Entity.Account
            {
                Email = model.Email,
                Password = model.Password
            });
            return new AccountDto
            {
                Id = account.Id,
                Email = account.Email,
                Password = account.Password,
                Confirmed = account.Confirmed,
                CreatedAt = account.CreatedAt
            };
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var accounts = await unitOfWork.AccountsRepository.GetAllAsync();
            return accounts.Select(account => new AccountDto
            {
                Id = account.Id,
                Email = account.Email,
                Password = account.Password,
                Confirmed = account.Confirmed,
                CreatedAt = account.CreatedAt,
                Todos = account.Todos.Select(todo => new ToDoItemDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    AccountId = todo.AccountId,
                    Completed = todo.Completed,
                    CreatedAt = todo.CreatedAt
                }).ToList()
            });
        }
    }
}
