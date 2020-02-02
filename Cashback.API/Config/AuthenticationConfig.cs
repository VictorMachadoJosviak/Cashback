using Cashback.API.Security;
using Cashback.API.Security.Intefaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.API.Config
{
    public static class AuthenticationConfig
    {
        public static void EnableAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticationProvider, AuthenticationProvider>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                      .AddJwtBearer(options =>
                      {
                          options.TokenValidationParameters = new TokenValidationParameters
                          {
                              ValidateIssuer = true,
                              ValidIssuer = configuration["JwtSettings:Issuer"],

                              ValidateAudience = true,
                              ValidAudience = configuration["JwtSettings:Audience"],

                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),

                              RequireExpirationTime = true,
                              ValidateLifetime = true,
                              ClockSkew = TimeSpan.Zero
                          };
                      });
        }
    }
}
