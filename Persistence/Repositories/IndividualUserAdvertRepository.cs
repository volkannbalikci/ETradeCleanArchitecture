using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class IndividualUserAdvertRepository : EFRepositoryBase<IndividualUserAdvert, Guid, BaseDbContext>, IIndividualUserAdvertRepository
{
    public IndividualUserAdvertRepository(BaseDbContext context) : base(context)
    {

    }
}
