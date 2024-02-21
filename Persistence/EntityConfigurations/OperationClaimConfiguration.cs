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

public class OperationClaimConfiguration : EntityTypeConfigurationBase<OperationClaim, Guid>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(o => o.UserOperationClaims);
    }
}
