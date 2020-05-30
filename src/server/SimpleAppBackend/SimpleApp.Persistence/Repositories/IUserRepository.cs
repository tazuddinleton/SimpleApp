using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
