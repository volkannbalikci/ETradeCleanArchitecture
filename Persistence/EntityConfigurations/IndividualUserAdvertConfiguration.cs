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

public class IndividualUserAdvertConfiguration : EntityTypeConfigurationBase<IndividualUserAdvert, Guid>
{
    public void Configure(EntityTypeBuilder<IndividualUserAdvert> builder)
    {
        builder.ToTable("IndividualUserAdverts").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.IndividulaUserId).HasColumnName("IndividulaUserId").IsRequired();
        builder.Property(i => i.AdvertId).HasColumnName("AdvertId").IsRequired();

        builder.HasOne(i => i.IndividualUser);
        builder.HasOne(i => i.Advert);
    }
}
