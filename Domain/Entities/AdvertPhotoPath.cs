using Core.Presistence.Repositories;

namespace Domain.Entities;

public class AdvertPhotoPath : EntityBase<Guid>
{
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }

    public virtual Advert? Advert { get; set; }
}
