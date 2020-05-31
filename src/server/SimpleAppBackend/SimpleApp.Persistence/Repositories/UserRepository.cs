using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimpleAppDbContext _context;


        public UserRepository(SimpleAppDbContext context)
        {
            _context = context;
        }
        
        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.Username == username && user.Password == password.ToSHA256());
        }
    }
}
