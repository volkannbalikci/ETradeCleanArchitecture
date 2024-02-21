using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Update;

public class UpdatedAdminResponse
{
    public Guid Id { get; set; }
    public Guid IndividualUserId { get; set; }
    public string RegisterNumber{ get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate{ get; set; }
}
