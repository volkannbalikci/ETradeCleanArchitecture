using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class CorporateUserRepository : EFRepositoryBase<CorporateUser, Guid, BaseDbContext>, ICorporateUserRepository
{
	public CorporateUserRepository(BaseDbContext context) : base(context)	
	{

	}
}
