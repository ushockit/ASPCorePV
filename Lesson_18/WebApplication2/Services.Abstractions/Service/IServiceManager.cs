using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions.Service
{
    public interface IServiceManager
    {
        public IToDosService ToDosService { get; }
        public IAccountsService AccountsService { get; }
    }
}
