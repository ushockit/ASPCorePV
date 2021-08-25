using Domain.Repository;
using Services.Abstractions.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IToDosService> _todosService;
        private readonly Lazy<IAccountsService> _accountsService;

        public IToDosService ToDosService => _todosService.Value;
        public IAccountsService AccountsService => _accountsService.Value;


        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _todosService = new Lazy<IToDosService>(() => new ToDosService(unitOfWork));
            _accountsService = new Lazy<IAccountsService>(() => new AccountsService(unitOfWork));
        }
    }
}
