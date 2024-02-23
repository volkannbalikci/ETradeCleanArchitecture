using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressListItemDto
{
    public Guid UserId { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string AddressPostalCode { get; set; }
    public string AddressDetails { get; set; }
    public bool UserAddressIsMain { get; set; }
}
