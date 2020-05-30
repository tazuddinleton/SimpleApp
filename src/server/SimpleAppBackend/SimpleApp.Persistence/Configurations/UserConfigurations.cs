using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApp.Domain.Entities;
using SimpleApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasData(new User() { Id = 1, Username = "tazuddin", Password = "password123".ToSHA256() });
            builder.HasData(new User() { Id = 2, Username = "loneranger", Password = "letmein".ToSHA256() });
        }
    }
}
