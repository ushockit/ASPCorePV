using System;
using CQRSProject.Domain.Entities;
using CQRSProject.Domain.Repositories;

namespace CQRSProject.Application.Interfaces
{
    public interface IServiceManager
    {
        IProductsService ProductsService { get; }
    }
}
