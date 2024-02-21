using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Create;

public class CreatedAdminResponse
{
    public Guid Id { get; set; }
    public Guid IndividualUserId { get; set; }
    public string RegisterNumber { get; set; }
    public DateTime CreatedDate { get; set; }
}
