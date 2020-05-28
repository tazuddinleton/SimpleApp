using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Persistence
{
    public class SimpleAppDbContext : DbContext
    {        
        public DbSet<Product> Products { get; set; }


        public SimpleAppDbContext(DbContextOptions<SimpleAppDbContext> options)
            :base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // applying entity type configurations here makes things a bit messy
            // So I moved it into a different location
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleAppDbContext).Assembly);            
        }
    }
}
