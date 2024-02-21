using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IIndividualUserAdvertRepository : IAsyncRepository<IndividualUserAdvert, Guid>, IRepository<IndividualUserAdvert, Guid>
{
}
