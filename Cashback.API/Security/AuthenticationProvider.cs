using Cashback.API.Security.Intefaces;
using Cashback.Infra.DTO.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.API.Security
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IConfiguration _config;

        public AuthenticationProvider(IConfiguration config)
        {
            _config = config;
        }
        public async Task<TokenDTO> GenerateToken(Guid userId)
        {
            var claims = new[]
              {
                    new Claim("userId", userId.ToString()), 
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                claims: claims,
                signingCredentials: credential,
                expires: DateTime.Now.AddMinutes(300),
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"]
            );

            return new TokenDTO
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = token.ValidTo,
                token_type = "bearer"
            };
        }
    }
}
