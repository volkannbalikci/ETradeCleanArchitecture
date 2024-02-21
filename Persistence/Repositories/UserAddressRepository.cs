using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserAddressRepository : EFRepositoryBase<UserAddress, Guid, BaseDbContext>, IUserAddressRepository
{
    public UserAddressRepository(BaseDbContext context) : base(context)
    {

    }
}
