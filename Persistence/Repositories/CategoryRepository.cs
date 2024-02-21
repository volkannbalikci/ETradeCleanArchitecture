using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryRepository : EFRepositoryBase<Category, Guid, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {

    }
}
