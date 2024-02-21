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

public class CorporateUserAdvertConfiguration : EntityTypeConfigurationBase<CorporateUserAdvert, Guid>
{
    public void Configure(EntityTypeBuilder<CorporateUserAdvert> builder)
    {
        builder.ToTable("CorporateUserAdverts").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CorporateUserId).HasColumnName("CorporateUserId").IsRequired();
        builder.Property(c => c.AdvertId).HasColumnName("AdvertId").IsRequired();

        builder.HasOne(c => c.CorporateUser);
        builder.HasOne(c => c.Advert);
    }
}
