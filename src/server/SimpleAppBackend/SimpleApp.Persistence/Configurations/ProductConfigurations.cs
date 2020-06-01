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
            int max = 12;
            for (int i = 1; i <= max; i++)
            {
                builder.HasData(new Product() 
                { 
                    ProductId = i, 
                    CategoryId = (i % 4)+1, 
                    ProductName = $"Product {i}", 
                    UnitPrice = 145.55M, 
                    Description = $"Product Description {i}",
                    DateCreated = DateTime.Now,
                    CreatedBy = "tazuddin"
                });
            }            
        }
    }
}
