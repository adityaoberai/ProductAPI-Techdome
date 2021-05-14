using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class ProductTypeContext : DbContext
    {
        public ProductTypeContext(DbContextOptions<ProductTypeContext> options) : base(options)
        {
        }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>()
                .HasKey(u => u.id);
        }
    }
}
