using Core.Presistence.Repositories;

namespace Domain.Entities;

public class District : EntityBase<Guid>
{
    public Guid CityId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }
    public virtual City? City { get; set; }
}
