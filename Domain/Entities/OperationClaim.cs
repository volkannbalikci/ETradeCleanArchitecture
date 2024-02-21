using Core.Presistence.Repositories;

namespace Domain.Entities;

public class OperationClaim : EntityBase<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set; }
}
