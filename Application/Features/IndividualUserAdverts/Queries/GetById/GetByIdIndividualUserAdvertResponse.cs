using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Queries.GetById;

public class GetByIdIndividualUserAdvertResponse
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public Guid IndividualUserId { get; set; }
    public Guid ProductId { get; set; }
    public string IndividualUserFirstName { get; set; }
    public string IndividualUserLastName { get; set; }
    public string IndividualUserUserName { get; set; }
    public string IndividualUserEmail { get; set; }
    public decimal AdvertPrice { get; set; }
    public string AdvertTitle { get; set; }
    public string AdvertDescription { get; set; }
}
