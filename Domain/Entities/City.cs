using Core.Presistence.Repositories;

namespace Domain.Entities;

public class City : EntityBase<Guid>
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Address>? Addresses { get;}
    public virtual ICollection<District>? Districts { get;}
    public virtual Country? Country { get; set; }

}
