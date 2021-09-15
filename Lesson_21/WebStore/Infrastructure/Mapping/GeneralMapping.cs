using AutoMapper;
using Domain.Entities;
using Infrastructure.Dtos.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>();
        }
    }
}
