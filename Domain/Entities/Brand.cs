using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Brand : EntityBase<Guid>
{
    public string Name { get; set; }
    public string WebsiteUrl { get; set; }

    public virtual ICollection<Product>? Products { get;}
}
