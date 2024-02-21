using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICityRepository : IAsyncRepository<City, Guid>, IRepository<City, Guid>
{
}
