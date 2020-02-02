using Cashback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Map
{
    public class StatusSaleConfiguration : IEntityTypeConfiguration<StatusSale>
    {
        public void Configure(EntityTypeBuilder<StatusSale> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedNever().IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired(true);            
        }
    }
}
