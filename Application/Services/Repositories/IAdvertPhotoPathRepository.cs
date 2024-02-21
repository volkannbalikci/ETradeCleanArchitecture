using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IAdvertPhotoPathRepository : IAsyncRepository<AdvertPhotoPath, Guid>, IRepository<AdvertPhotoPath, Guid>
{
}
