using Cashback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Map
{
    public class ConfigurationIntegrationConfiguration : IEntityTypeConfiguration<ConfigurationIntegration>
    {
        public void Configure(EntityTypeBuilder<ConfigurationIntegration> builder)
        {
            builder.HasKey(t => t.Id);            
            builder.Property(x => x.Token).HasMaxLength(2000).IsRequired(true);            
            builder.Property(x => x.Url).HasMaxLength(2000).IsRequired(true);            
            builder.Property(x => x.TokenType).HasMaxLength(20).IsRequired(true);            
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired(true);            
        }
    }
}
