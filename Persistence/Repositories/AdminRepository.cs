using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdminRepository : EFRepositoryBase<Admin, Guid, BaseDbContext>, IAdminRepository
{
    public AdminRepository(BaseDbContext context) : base(context)
    {

    }
}
