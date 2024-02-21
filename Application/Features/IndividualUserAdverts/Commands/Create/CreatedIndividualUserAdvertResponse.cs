using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Commands.Create;

public class CreatedIndividualUserAdvertResponse
{
    public Guid Id { get; set; }
    public Guid IndividulaUserId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime CreatedDate { get; set; }
}
