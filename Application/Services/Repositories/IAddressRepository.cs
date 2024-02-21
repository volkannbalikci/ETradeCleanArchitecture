using Core.Presistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;

public interface IAddressRepository : IAsyncRepository<Address, Guid>, IRepository<Address, Guid>
{
}
