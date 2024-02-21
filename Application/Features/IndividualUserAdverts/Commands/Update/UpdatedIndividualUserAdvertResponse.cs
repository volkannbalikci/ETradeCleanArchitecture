using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Commands.Update;

public class UpdatedIndividualUserAdvertResponse
{
    public Guid Id { get; set; }
    public Guid IndividulaUserId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
