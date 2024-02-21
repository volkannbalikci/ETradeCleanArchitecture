using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Commands.Delete;
using Application.Features.OperationClaims.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<OperationClaim, CreateOperationClaimCommand>();
		CreateMap<OperationClaim, CreatedOperationClaimResponse>();
		CreateMap<OperationClaim, DeleteOperationClaimCommand>();
		CreateMap<OperationClaim, DeletedOperationClaimResponse>();
		CreateMap<OperationClaim, UpdateOperationClaimCommand>();
		CreateMap<OperationClaim, UpdatedOperationClaimResponse>();
	}
}
