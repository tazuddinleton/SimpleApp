using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.Common;
using SimpleApp.Domain.Entities;
using SimpleApp.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.Persistence
{
    public class SimpleAppDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUser;
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        public SimpleAppDbContext(DbContextOptions<SimpleAppDbContext> options, ICurrentUserService currentUserService)
            :base(options)
        {
            _currentUser = currentUserService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // applying entity type configurations here makes things a bit messy
            // So I moved it into a different location
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleAppDbContext).Assembly);            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (item.State)
                {                    
                    case EntityState.Modified:
                        item.Entity.LastUpdated = DateTime.Now;
                        item.Entity.UpdatedBy = _currentUser.UserId;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedBy = _currentUser.UserId;
                        item.Entity.DateCreated = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
