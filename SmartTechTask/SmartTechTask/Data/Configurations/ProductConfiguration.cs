using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id")
                   .HasColumnType("int");
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("nvarchar(50)");
            builder.Property(s => s.Price)
                   .IsRequired()
                   .HasColumnName("Price")
                   .HasColumnType("float");
            builder.Property(s => s.Photo)
                   .HasColumnName("Photo")
                   .HasColumnType("nvarchar(50)");
            builder.Property(s => s.LastUpdated)
                   .HasColumnName("LastUpdated")
                   .HasColumnType("datetime");
        }
    }
}
