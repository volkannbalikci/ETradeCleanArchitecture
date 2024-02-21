using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityConfigurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : EntityTypeConfigurationBase<Product, Guid>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(p => p.Adverts);
        builder.HasOne(p => p.Brand);
        builder.HasOne(p => p.Category);
    }
}
