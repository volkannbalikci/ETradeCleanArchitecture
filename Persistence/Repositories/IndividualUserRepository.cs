using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class IndividualUserRepository : EFRepositoryBase<IndividualUser, Guid, BaseDbContext>, IIndividualUserRepository
{
    public IndividualUserRepository(BaseDbContext context) : base(context)
    {

    }
}
