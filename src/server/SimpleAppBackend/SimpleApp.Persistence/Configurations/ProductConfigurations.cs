using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,8)");

            for (int i = 1; i <= 10; i++)
            {
                builder.HasData(new Product() { ProductId = i, ProductName = $"Product {i}", UnitPrice = 145.55M, Description = $"Product Description {i}" });
            }            
        }
    }
}
