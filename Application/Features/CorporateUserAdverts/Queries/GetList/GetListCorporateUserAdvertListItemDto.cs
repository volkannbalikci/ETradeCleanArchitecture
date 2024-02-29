using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Queries.GetList;

public class GetListCorporateUserAdvertListItemDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public Guid IndividualUserId { get; set; }
    public Guid ProductId { get; set; }
    public string CorporateUserCompanyName { get; set; }
    public string CorporateUserTaxIdentityNumber { get; set; }
    public decimal AdvertPrice { get; set; }
    public string AdvertTitle { get; set; }
    public string AdvertDescription { get; set; }
}
