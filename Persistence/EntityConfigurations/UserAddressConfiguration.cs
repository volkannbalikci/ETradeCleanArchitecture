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

public class UserAddressConfiguration : EntityTypeConfigurationBase<UserAddress, Guid>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(u => u.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(u => u.IsMain).HasColumnName("IsMain").IsRequired();

        builder.HasMany(u => u.Addresses);
        builder.HasOne(u => u.User);
    }
}
