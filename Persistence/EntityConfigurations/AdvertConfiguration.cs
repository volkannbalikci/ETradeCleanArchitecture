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

public class AdvertConfiguration : EntityTypeConfigurationBase<Advert, Guid>
{
    public void Configure(EntityTypeBuilder<Advert> builder)
    {
        builder.ToTable("Adverts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(a => a.IndividualUserId).HasColumnName("IndividualUserId").IsRequired();
        builder.Property(a => a.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(a => a.Price).HasColumnName("Price").IsRequired();
        builder.Property(a => a.Title).HasColumnName("Title").IsRequired();
        builder.Property(a => a.Description).HasColumnName("Description").IsRequired();

        builder.HasMany(a => a.AdvertPhotoPaths);
        builder.HasMany(a => a.IndividualUserAdverts);
        builder.HasOne(a => a.Address);
        builder.HasOne(a => a.IndividualUser);
        builder.HasOne(a => a.Product);
    }
}
