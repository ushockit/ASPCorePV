using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Dtos.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DbServices
{
    internal sealed class ProductsService : IProductsService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateAsync(CreateProductDTO product, CancellationToken cancellationToken = default)
        {
            var prod = await _unitOfWork.ProductsRepository.CreateAsync(_mapper.Map<Product>(product));
            return _mapper.Map<ProductDTO>(prod);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var products = await _unitOfWork.ProductsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
