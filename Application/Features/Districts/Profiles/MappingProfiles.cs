using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Districts.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<District, CreateDistrictCommand>().ReverseMap();
		CreateMap<District, CreatedDistrictResponse>().ReverseMap();
		CreateMap<District, DeleteDistrictCommand>().ReverseMap();
		CreateMap<District, DeletedDistrictResponse>().ReverseMap();
		CreateMap<District, UpdateDistrictCommand>().ReverseMap();
		CreateMap<District, UpdatedDistrictResponse>().ReverseMap();

		CreateMap<Paginate<District>, GetListResponse<GetListDistrictListItemDto>>().ReverseMap();
		CreateMap<District, GetListDistrictListItemDto>().ReverseMap();
		CreateMap<District, GetByIdDistrictResponse>().ReverseMap();
	}
}
