using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CityRepository : EFRepositoryBase<City, Guid, BaseDbContext>, ICityRepository
{
    public CityRepository(BaseDbContext context) : base(context)
    {

    }
}
