using Core.Presistence.Repositories;

namespace Domain.Entities;

public class Address : EntityBase<Guid>
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

    public virtual ICollection<Advert>? Adverts { get; set; }
    public virtual UserAddress? UserAddress { get; set; }
    public virtual Country? Country { get; set; }
    public virtual City? City { get; set; }
    public virtual District? District { get; set; }
}
