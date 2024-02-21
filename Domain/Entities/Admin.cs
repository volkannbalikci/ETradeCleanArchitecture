using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Admin : EntityBase<Guid>
{
    public Guid IndividualUserId { get; set; }
    public string RegisterNumber 
    {
        get 
        {
            return this.IndividualUser.FirstName[0] + this.IndividualUser.LastName[0] + this.IndividualUserId.ToString();
        } 
    }

    public virtual IndividualUser IndividualUser { get; set; }
}
