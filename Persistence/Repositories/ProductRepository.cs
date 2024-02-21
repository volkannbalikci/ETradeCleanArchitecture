using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductRepository : EFRepositoryBase<Product, Guid, BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {

    }
}
