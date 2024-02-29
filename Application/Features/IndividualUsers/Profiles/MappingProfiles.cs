using Application.Features.IndividualUsers.Commands.Create;
using Application.Features.IndividualUsers.Commands.Delete;
using Application.Features.IndividualUsers.Commands.Update;
using Application.Features.IndividualUsers.Queries.GetById;
using Application.Features.IndividualUsers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUsers.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<IndividualUser, CreateIndividualUserCommand>().ReverseMap();
		CreateMap<IndividualUser, CreatedIndividualUserResponse>().ReverseMap();
		CreateMap<IndividualUser, DeleteIndividualUserCommand>().ReverseMap();
		CreateMap<IndividualUser, DeletedIndividualUserResponse>().ReverseMap();
		CreateMap<IndividualUser, UpdateIndividualUserCommand>().ReverseMap();
		CreateMap<IndividualUser, UpdatedIndividualUserReponse>().ReverseMap();

		CreateMap<Paginate<IndividualUser>, GetListResponse<GetListIndividualUserListItemDto>>().ReverseMap();
		CreateMap<IndividualUser, GetListIndividualUserListItemDto>().ReverseMap();
		CreateMap<IndividualUser, GetByIdIndividualUserResponse>().ReverseMap();
	}
}
