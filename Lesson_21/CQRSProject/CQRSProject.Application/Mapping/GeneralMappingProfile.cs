using System;
using AutoMapper;
using CQRSProject.Application.Feautures.Queries.GetAllProducts;
using CQRSProject.Domain.Entities;

namespace CQRSProject.Application.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Product, GetAllProductsQueryResponse>().ReverseMap();
        }
    }
}
