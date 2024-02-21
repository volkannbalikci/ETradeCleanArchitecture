using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Create;

public class CreatedCityResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
}
