using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Country : EntityBase<Guid>
{
    public string Name { get; set; }
    public string ShortName { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }
    public virtual ICollection<City>? Cities { get; set; }
}
