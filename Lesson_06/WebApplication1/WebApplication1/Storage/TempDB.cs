using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Storage.Models;

namespace WebApplication1.Storage
{
    public class TempDB
    {
        public List<Category> Categories { get; }
        public List<Product> Products { get; }

        public TempDB()
        {
            Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" },
                new Category { Id = 3, Name = "Category 3" },
                new Category { Id = 4, Name = "Category 4" },
                new Category { Id = 5, Name = "Category 5" },
            };

            Products = new List<Product>
            {
                new Product { Id = 1, Title = "Product 1", Description = "Some description of product 1", CategoryId = 1, Price = 100 },
                new Product { Id = 2, Title = "Product 2", Description = "Some description of product 2", CategoryId = 2, Price = 120 },
                new Product { Id = 3, Title = "Product 3", Description = "Some description of product 3", CategoryId = 1, Price = 55 },
                new Product { Id = 4, Title = "Product 4", Description = "Some description of product 4", CategoryId = 4, Price = 22 },
                new Product { Id = 5, Title = "Product 5", Description = "Some description of product 5", CategoryId = 3, Price = 600 },
                new Product { Id = 6, Title = "Product 6", Description = "Some description of product 6", CategoryId = 5, Price = 321 },
                new Product { Id = 7, Title = "Product 7", Description = "Some description of product 7", CategoryId = 4, Price = 666 },
                new Product { Id = 8, Title = "Product 8", Description = "Some description of product 8", CategoryId = 3, Price = 309 },
                new Product { Id = 9, Title = "Product 9", Description = "Some description of product 9", CategoryId = 2, Price = 1000 },
                new Product { Id = 10, Title = "Product 10", Description = "Some description of product 10", CategoryId = 5, Price = 1200 },
            };
        }
    }
}
