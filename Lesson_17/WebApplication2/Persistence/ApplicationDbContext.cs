using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDos { get; set; }
        public DbSet<Account> Accounts { get; set; }
        
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
