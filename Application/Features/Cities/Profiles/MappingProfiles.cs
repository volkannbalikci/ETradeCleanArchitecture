using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<City, CreateCityCommand>().ReverseMap();
		CreateMap<City, CreatedCityResponse>().ReverseMap();
		CreateMap<City, DeleteCityCommand>().ReverseMap();
		CreateMap<City, DeletedCityResponse>().ReverseMap();
		CreateMap<City, UpdateCityCommand>().ReverseMap();
		CreateMap<City, UpdatedCityResponse>().ReverseMap();

		CreateMap<Paginate<City>, GetListResponse<GetListCityListItemDto>>().ReverseMap();
		CreateMap<City, GetListCityListItemDto>()
			.ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
			.ForMember(destinationMember: a => a.CountryShortName, memberOptions: opt => opt.MapFrom(a => a.Country.ShortName)).ReverseMap();
		
		CreateMap<City, GetByIdCityResponse>()
            .ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
            .ForMember(destinationMember: a => a.CountryShortName, memberOptions: opt => opt.MapFrom(a => a.Country.ShortName)).ReverseMap();

    }
}
