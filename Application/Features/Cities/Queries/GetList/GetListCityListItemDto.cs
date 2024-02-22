using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetList;

public class GetListCityListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }
    public string CountryShortName { get; set; }
}
