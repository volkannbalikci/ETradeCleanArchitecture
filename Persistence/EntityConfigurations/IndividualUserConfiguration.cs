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

public class IndividualUserConfiguration : EntityTypeConfigurationBase<IndividualUser, Guid>
{
    public void Configure(EntityTypeBuilder<IndividualUser> builder)
    {
        builder.ToTable("IndividualUsers").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("id").IsRequired();
        builder.Property(i => i.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(i => i.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(i => i.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(i => i.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(i => i.Email).HasColumnName("Email").IsRequired();

        builder.HasOne(i => i.User);
        builder.HasMany(i => i.IndividualUserAdverts);
        builder.HasMany(i => i.Admins);
        builder.HasMany(i => i.Adverts);
    }
}
