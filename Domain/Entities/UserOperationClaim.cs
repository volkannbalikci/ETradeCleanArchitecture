using Core.Presistence.Repositories;

namespace Domain.Entities;

public class UserOperationClaim : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public virtual User? User { get; set; }
    public virtual OperationClaim? OperationClaim { get; set; }
}
