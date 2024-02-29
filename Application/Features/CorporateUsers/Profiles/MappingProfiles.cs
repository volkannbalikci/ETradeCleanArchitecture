using Application.Features.Addresses.Commands.Create;
using Application.Features.CorporateUsers.Commands.Create;
using Application.Features.CorporateUsers.Commands.Delete;
using Application.Features.CorporateUsers.Commands.Update;
using Application.Features.CorporateUsers.Queries.GetById;
using Application.Features.CorporateUsers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUsers.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<CorporateUser, CreateCorporateUserCommand>().ReverseMap();
		CreateMap<CorporateUser, CreatedCorporateUserResponse>().ReverseMap();
		CreateMap<CorporateUser, DeleteCorporateUserCommand>().ReverseMap();
		CreateMap<CorporateUser, DeletedCorporateUserResponse>().ReverseMap();
		CreateMap<CorporateUser, UpdateCorporateUserCommand>().ReverseMap();
		CreateMap<CorporateUser, UpdatedCorporateUserResponse>().ReverseMap();
		
		CreateMap<Paginate<CorporateUser>, GetListResponse<GetListCorporateUserListItemDto>>().ReverseMap();
		CreateMap<CorporateUser, GetListCorporateUserListItemDto>().ReverseMap();
		CreateMap<CorporateUser, GetByIdCorporateUserResponse>().ReverseMap();


	}
}
