using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CountryRepository : EFRepositoryBase<Country, Guid, BaseDbContext>, ICountryRepository
{
    public CountryRepository(BaseDbContext context) : base(context)
    {

    }
}
