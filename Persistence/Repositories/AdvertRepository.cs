using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertRepository : EFRepositoryBase<Advert, Guid, BaseDbContext>, IAdvertRepository
{
    public AdvertRepository(BaseDbContext context) : base(context)
    {

    }
}
