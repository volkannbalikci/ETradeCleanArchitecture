using Core.Presistence.Repositories;

namespace Domain.Entities
{
    public class UserAddress : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public bool IsMain { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
