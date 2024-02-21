using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>();
		CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>();
		CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>();
		CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>();
		CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>();
		CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>();
	}
}
