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
        private readonly IJwtTokenService _tokenService;
        public AccountController(IUserRepository userRepo, IJwtTokenService tokenService)
        {
            _userRepository = userRepo;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [Consumes("application/json")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userRepository.GetByUsernameAndPassword(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            return Ok(new { Token = _tokenService.GenerateToken(user), _tokenService.Descriptor.Expires});
        }
    }
        
}
