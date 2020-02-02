using Cashback.Infra.Presistence;
using Cashback.Repository;
using Cashback.Repository.Interfaces;
using Cashback.Services;
using Cashback.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cashback.Infra.Transactions;

namespace Cashback.IoC
{
    public static class DIManager
    {
        public static void InitializeContainer(this IServiceCollection services, IConfiguration configuration)
        {
            InitializeDataContext(services, configuration);
            InitializeRepositories(services);
            InitializeServices(services);            
        }

        private static void InitializeServices(IServiceCollection services)
        {
            services.AddScoped<IResellerService, ResellerService>();
            services.AddScoped<ISaleService, SaleService>();
        }

        private static void InitializeRepositories(IServiceCollection services)
        {
            services.AddScoped<IResellerRepository, ResellerRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IConfigurationIntegrationRepository, ConfigurationIntegrationRepository>();
        }

        private static void InitializeDataContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration["DefaultConnection"]));
            services.AddScoped<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
