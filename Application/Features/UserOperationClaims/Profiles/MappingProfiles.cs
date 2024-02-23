using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using Application.Features.UserOperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
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
		CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
		CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
		CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
		CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();
		CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
		CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();

		CreateMap<Paginate<UserOperationClaim>, GetListResponse<GetListUserOperationClaimListItemDto>>().ReverseMap();
		CreateMap<UserOperationClaim, GetListUserOperationClaimListItemDto>()
			.ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.UserId))
			.ForMember(destinationMember: u => u.OperationClaimName, memberOptions: opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();
		
		CreateMap<UserOperationClaim, GetByIdUserOperationClaimResponse>()
			.ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.UserId))
			.ForMember(destinationMember: u => u.OperationClaimName, memberOptions: opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();
	}
}
