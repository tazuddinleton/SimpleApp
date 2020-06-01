using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SimpleAppDbContext _context;

        public CategoryRepository(SimpleAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
