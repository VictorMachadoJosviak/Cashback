using Cashback.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Map
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.ResellerId).IsRequired(true);
            builder.Property(x => x.StatusSaleId).IsRequired(true);
            builder.Property(x => x.Code).HasMaxLength(20).IsRequired(true);
            builder.HasIndex(x => x.Code).IsUnique(true);
        }
    }
}
