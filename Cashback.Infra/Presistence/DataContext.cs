using Cashback.Domain.Entities;
using Cashback.Domain.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.Presistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Reseller> Resellers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<StatusSale> StatusSales { get; set; }
        public DbSet<ConfigurationIntegration> ConfigurationIntegrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ResellerConfiguration());
            modelBuilder.ApplyConfiguration(new StatusSaleConfiguration());


        }

    }
}
