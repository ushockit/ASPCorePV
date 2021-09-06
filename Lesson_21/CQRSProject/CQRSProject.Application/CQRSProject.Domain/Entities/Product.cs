using System;
namespace CQRSProject.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
