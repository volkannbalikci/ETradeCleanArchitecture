using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Commands.Create;

public class CreatedCorporateUserAdvertResponse
{
    public Guid Id { get; set; }
    public Guid CorporateUserId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime CreatedDate { get; set; }
}
