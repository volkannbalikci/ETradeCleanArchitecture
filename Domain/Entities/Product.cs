using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Product : EntityBase<Guid>
{
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Advert>? Adverts { get;}
    public virtual Brand? Brand { get; set; }
    public virtual Category? Category { get; set; }
}