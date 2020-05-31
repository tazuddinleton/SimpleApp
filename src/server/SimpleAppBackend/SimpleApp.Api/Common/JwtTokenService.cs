using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleApp.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace SimpleApp.Api.Common
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
        SecurityTokenDescriptor Descriptor { get; }
    }
    public class JwtTokenService : IJwtTokenService
    {
        private readonly AppSettings _appSettings;
        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public SecurityTokenDescriptor Descriptor { get; set; }

        public string GenerateToken(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(_appSettings.TokenSecrete.ToBytes());
                var handler = new JwtSecurityTokenHandler();
                Descriptor = new SecurityTokenDescriptor();
                Descriptor
                    .Subject =
                    new ClaimsIdentity(
                        new Claim[] { new Claim(ClaimTypes.NameIdentifier, user.Username) }
                    );

                Descriptor.Expires = DateTime.Now.AddHours(10);
                Descriptor.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var securityToken = handler.CreateToken(Descriptor);
                var token = handler.WriteToken(securityToken);
                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }


    }
        
}
