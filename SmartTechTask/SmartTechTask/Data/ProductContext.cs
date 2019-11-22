using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartTechTask.Data.Configurations;
using SmartTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }
        public IConfiguration Configuration { get; }
        public ProductContext(DbContextOptions<ProductContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration["ConnectionString:SmartTechDB"]);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }



    }
}
