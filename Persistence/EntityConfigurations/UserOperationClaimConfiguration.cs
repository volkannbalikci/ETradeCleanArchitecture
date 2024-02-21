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

public class UserOperationClaimConfiguration : EntityTypeConfigurationBase<UserOperationClaim, Guid>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(u => u.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(o => o.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasOne(u => u.User);
        builder.HasOne(u => u.OperationClaim);
    }
}
