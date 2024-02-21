using Application.Features.Commands.Create;
using Application.Features.UserAddresses.Commands.Create;
using Application.Features.UserAddresses.Commands.Delete;
using Application.Features.UserAddresses.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserAddresses.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<UserAddress, CreateUserAddressCommand>();
		CreateMap<UserAddress, CreatedUserAddressResponse>();
		CreateMap<UserAddress, DeleteUserAddressCommand>();
		CreateMap<UserAddress, DeletedUserAddressResponse>();
		CreateMap<UserAddress, UpdateUserAddressCommand>();
		CreateMap<UserAddress, UpdatedUserAddressResponse>();
	}
}
