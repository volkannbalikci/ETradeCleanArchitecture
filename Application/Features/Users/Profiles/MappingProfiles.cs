using Application.Features.UserAddresses.Commands.Update;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<User, CreateUserCommand>();
		CreateMap<User, CreatedUserResponse>();
		CreateMap<User, DeleteUserCommand>();
		CreateMap<User, DeletedUserResponse>();
		CreateMap<User, UpdateUserCommand>();
		CreateMap<User, UpdatedUserResponse>();
	}
}
