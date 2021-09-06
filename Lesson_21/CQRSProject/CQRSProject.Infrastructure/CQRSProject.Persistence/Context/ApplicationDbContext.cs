using System;
using CQRSProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Product1", Price = 10, Description = "Some product 1" },
                new Product { Id = 2, Title = "Product2", Price = 20, Description = "Some product 2" },
                new Product { Id = 3, Title = "Product3", Price = 30, Description = "Some product 3" }
                );
        }
    }
}
