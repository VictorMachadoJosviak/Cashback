using Cashback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Map
{
    public class ResellerConfiguration : IEntityTypeConfiguration<Reseller>
    {
        public void Configure(EntityTypeBuilder<Reseller> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(500);
            
            builder.Property(x => x.Email).HasMaxLength(500).IsRequired(true);
            builder.HasIndex(x => x.Email).IsUnique(true);

            builder.Property(x => x.CPF).HasMaxLength(11).IsRequired(true);
            builder.HasIndex(x => x.CPF).IsUnique(true);

            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(500);
        }
    }
}
