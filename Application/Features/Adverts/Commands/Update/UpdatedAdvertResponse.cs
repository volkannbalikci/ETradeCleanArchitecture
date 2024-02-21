using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Commands.Update;

public class UpdatedAdvertResponse
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public Guid IndividualUserId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
