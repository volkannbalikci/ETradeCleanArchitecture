using Core.Presistence.Repositories;

namespace Domain.Entities;

public class IndividualUserAdvert : EntityBase<Guid>
{
    public Guid IndividulaUserId { get; set; }
    public Guid AdvertId { get; set; }

    public virtual IndividualUser? IndividualUser { get; set; }
    public virtual Advert? Advert { get; set; }
}
