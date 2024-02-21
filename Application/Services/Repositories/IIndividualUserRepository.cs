using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IIndividualUserRepository : IAsyncRepository<IndividualUser, Guid>, IRepository<IndividualUser, Guid>
{
}
