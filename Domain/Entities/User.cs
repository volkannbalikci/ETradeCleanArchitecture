using Core.Presistence.Repositories;

namespace Domain.Entities;

public class User : EntityBase<Guid>
{ 
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Status { get; set; }

    public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set;}
    public virtual ICollection<CorporateUser>? CorporateUsers { get; set;}
    public virtual ICollection<IndividualUser>? IndividualUsers { get; set;}
    public virtual ICollection<UserAddress>? UserAddresses { get; set;}
}
