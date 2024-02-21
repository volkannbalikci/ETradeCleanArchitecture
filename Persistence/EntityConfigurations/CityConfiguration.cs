using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityConfigurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class CityConfiguration : EntityTypeConfigurationBase<City, Guid>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(c => c.Addresses);
        builder.HasMany(c => c.Districts);
        builder.HasOne(c => c.Country);
    }
}
