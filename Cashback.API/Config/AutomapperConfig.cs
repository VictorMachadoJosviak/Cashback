using AutoMapper;
using Cashback.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.API.Config
{
    public static class AutomapperConfig
    {
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainDTOMapper).Assembly);
            services.AddSingleton<DomainDTOMapper>();
            services.AddSingleton<DTODomainMapper>();
        }
    }
}
