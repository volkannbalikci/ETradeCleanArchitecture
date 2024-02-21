using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserAddressRepository : IAsyncRepository<UserAddress, Guid>, IRepository<UserAddress, Guid>
{
}
