using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Product>? Products { get;}
}
