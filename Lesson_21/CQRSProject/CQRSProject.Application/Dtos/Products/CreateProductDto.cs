using System;
namespace CQRSProject.Application.Dtos.Products
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
