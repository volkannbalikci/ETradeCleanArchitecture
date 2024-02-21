using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Create;

public class CreatedAddressResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }
    public DateTime CreatedDate { get; set; }
}
