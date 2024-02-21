using Core.Presistence.Repositories;

namespace Domain.Entities;

public class IndividualUser : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<IndividualUserAdvert> IndividualUserAdverts { get; set; }
    public virtual ICollection<Admin> Admins { get; set; }
    public virtual ICollection<Advert> Adverts { get; set; }
}
