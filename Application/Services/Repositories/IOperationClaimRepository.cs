using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, Guid>, IRepository<OperationClaim, Guid>
{
}
