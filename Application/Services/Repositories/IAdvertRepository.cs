using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IAdvertRepository : IAsyncRepository<Advert, Guid>, IRepository<Advert, Guid>
{
}
