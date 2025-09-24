using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Configuration;
using Shop.Application.Security;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _settings;

        public JwtTokenService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public string GenerateToken(User user, string userSecretCode)
        {
            var securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_settings.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim("SecretCode", userSecretCode)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _settings.Issuer,
                _settings.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(_settings.ExpireMinutes),
                credentials);

            string token = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
