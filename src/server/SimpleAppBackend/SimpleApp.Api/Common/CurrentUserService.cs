using Microsoft.AspNetCore.Http;
using SimpleApp.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleApp.Api.Common
{

    
    public class CurrentUserService : ICurrentUserService
    {
        private readonly string _userId;
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _userId = accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId => _userId;
    }
}
