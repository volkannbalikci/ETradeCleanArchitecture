using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressResponse
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

}
