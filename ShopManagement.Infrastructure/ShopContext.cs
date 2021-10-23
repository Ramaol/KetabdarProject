using System;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.BookAgg;
using ShopManagement.Domain.BookCateguryAgg;
using ShopManagement.Infrastructure.Mapping.cs;

namespace ShopManagement.Infrastructure
{
    public class ShopContext : DbContext
    {
        public DbSet<BookCategury> BookCateguries { get; set; }
        public DbSet<Book> Books { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {   
            var assembly = typeof(BookCateguryMapping).Assembly;
            ModelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(ModelBuilder);
        }

    }
}
