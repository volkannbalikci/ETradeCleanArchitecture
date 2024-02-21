using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICountryRepository : IAsyncRepository<Country, Guid>, IRepository<Country, Guid>
{
}
