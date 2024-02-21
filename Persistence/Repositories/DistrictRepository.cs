using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DistrictRepository : EFRepositoryBase<District, Guid, BaseDbContext>, IDistrictRepository
{
    public DistrictRepository(BaseDbContext context) : base(context)
    {

    }
}
