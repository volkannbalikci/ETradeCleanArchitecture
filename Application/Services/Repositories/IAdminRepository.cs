using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IAdminRepository : IAsyncRepository<Admin, Guid>, IRepository<Admin, Guid>
{
}
