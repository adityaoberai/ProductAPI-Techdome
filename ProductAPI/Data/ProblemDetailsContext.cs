using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class ProblemDetailsContext : DbContext
    {
        public ProblemDetailsContext(DbContextOptions<ProblemDetailsContext> options) : base(options)
        {
        }
        public DbSet<ProblemDetails> ProblemDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProblemDetails>()
                .HasNoKey();
        }
    }
}
