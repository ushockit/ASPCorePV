using Domain.Repository;
using Services.Abstractions.Dto.Account;
using Services.Abstractions.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class AccountsService : IAccountsService
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountsService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public Task<IEnumerable<AccountDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
