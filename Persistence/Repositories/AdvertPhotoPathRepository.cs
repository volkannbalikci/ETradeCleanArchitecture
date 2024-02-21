using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertPhotoPathRepository : EFRepositoryBase<AdvertPhotoPath, Guid, BaseDbContext>, IAdvertPhotoPathRepository
{
	public AdvertPhotoPathRepository(BaseDbContext context) : base(context)
	{

	}
}
