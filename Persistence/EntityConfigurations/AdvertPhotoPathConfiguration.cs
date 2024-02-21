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

public class AdvertPhotoPathConfiguration : EntityTypeConfigurationBase<AdvertPhotoPath, Guid>
{
    public void Configure(EntityTypeBuilder<AdvertPhotoPath> builder)
    {
        builder.ToTable("AdvertPhotoPaths").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(a => a.PhotoPath).HasColumnName("PhotoPath").IsRequired();

        builder.HasOne(a => a.Advert);
    }
}
