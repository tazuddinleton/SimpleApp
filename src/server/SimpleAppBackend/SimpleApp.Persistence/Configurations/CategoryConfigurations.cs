using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            for (int i = 1; i <= 4; i++)
            {
                builder.HasData(new Category() { CategoryId = i, CategoryName = $"Category {i}", Description = $"Description {i}" });
            }
        }
    }
}
