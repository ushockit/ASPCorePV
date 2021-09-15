using Application.Features.Commands.CreateProduct;
using Application.Features.Queries.GetAllProducts;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Dtos.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateProductCommandRequest, CreateProductDTO>();
            CreateMap<ProductDTO, CreateProductCommandResponse>().ReverseMap();
            CreateMap<ProductDTO, GetAllProductsQueryResponse>().ReverseMap();
            //CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
