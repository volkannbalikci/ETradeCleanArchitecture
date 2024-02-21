﻿using Core.Presistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{
}
