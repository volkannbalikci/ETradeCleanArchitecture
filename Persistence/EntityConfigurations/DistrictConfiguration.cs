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

public class DistrictConfiguration : EntityTypeConfigurationBase<District, Guid>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(d => d.Addresses);
        builder.HasOne(d => d.City);
    }
}
