using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cashback.API.Config
{
    public static class SwaggerConfig
    {
        public static void EnableSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cashback API",
                    Description = "Api Cashback Boticario",
                    Contact = new OpenApiContact
                    {
                        Name = "Boticario",
                        Email = string.Empty,
                        Url = new Uri("https://www.boticario.com.br/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Todos os direitos reservados",
                        Url = new Uri("https://www.boticario.com.br/")
                    }
                });
                c.AddSecurityDefinition("Bearer",
                     new OpenApiSecurityScheme
                     {
                         In = ParameterLocation.Header,
                         Description = "Insira a palavra 'Bearer' sequido de espaço e token JWT",
                         Name = "Authorization",
                         Type = SecuritySchemeType.ApiKey
                     }
                );
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

    }
}
