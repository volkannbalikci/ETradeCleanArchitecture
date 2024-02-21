using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EFRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {

    }
}
