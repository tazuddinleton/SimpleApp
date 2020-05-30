using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Api.Common;
using SimpleApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }
        
        [HttpPost]
        [Route("login")]
        [Consumes("application/json")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userRepository.GetByUsernameAndPassword(model.Username, model.Password);
            return Ok();
        }
    }
}
