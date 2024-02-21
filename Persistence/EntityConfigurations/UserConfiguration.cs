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

public class UserConfiguration : EntityTypeConfigurationBase<User, Guid>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").HasColumnType("varbinary(MAX)");
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").HasColumnType("varbinary(MAX)");
        builder.Property(u => u.Status).HasColumnName("Status").IsRequired();

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.CorporateUsers);
        builder.HasMany(u => u.IndividualUsers);
        builder.HasMany(u => u.UserAddresses);
    }
}
