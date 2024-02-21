using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OperationClaimRepository : EFRepositoryBase<OperationClaim, Guid, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {

    }
}
