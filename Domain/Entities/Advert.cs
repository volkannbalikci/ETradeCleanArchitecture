using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Advert : EntityBase<Guid>
{
    public Guid AddressId { get; set; }
    public Guid IndividualUserId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual ICollection<AdvertPhotoPath>? AdvertPhotoPaths { get; set; }
    public virtual ICollection<IndividualUserAdvert>? IndividualUserAdverts { get; set; }
    public virtual ICollection<CorporateUserAdvert> CorporateUserAdverts { get; set; }
    public virtual Address? Address { get; set; }
    public virtual IndividualUser? IndividualUser { get; set; }
    public virtual Product? Product { get; set; }
}
