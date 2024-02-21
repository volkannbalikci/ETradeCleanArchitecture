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

public class AddressConfiguration : EntityTypeConfigurationBase<Address, Guid>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(a => a.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(a => a.DistrictId).HasColumnName("DistrictId").IsRequired();
        builder.Property(a => a.PostalCode).HasColumnName("PostalCode").IsRequired();
        builder.Property(a => a.AddressDetails).HasColumnName("AddressDetails").IsRequired();

        builder.HasMany(a => a.Adverts);
        builder.HasOne(a => a.UserAddress);
        builder.HasOne(a => a.Country);
        builder.HasOne(a => a.City);
        builder.HasOne(a => a.District);
    }
}

