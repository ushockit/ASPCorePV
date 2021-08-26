using Services.Abstractions.Dto.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Service
{
    public interface IAccountsService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AccountDto> CreateAsync(CreateAccountDto model, CancellationToken cancellationToken = default);

    }
}
