using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Address, CreateAddressCommand>().ReverseMap();
		CreateMap<Address, CreatedAddressResponse>().ReverseMap();
		CreateMap<Address, UpdateAddressCommand>().ReverseMap();
		CreateMap<Address, UpdatedAddressResponse>().ReverseMap();
		CreateMap<Address, DeleteAddressCommand>().ReverseMap();
		CreateMap<Address, DeletedAddressResponse>().ReverseMap();
		
		CreateMap<Paginate<Address>, GetListResponse<GetListAddressListItemDto>>().ReverseMap();
		CreateMap<Address, GetListAddressListItemDto>()
			.ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Country.Name))
			.ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.City.Name))
			.ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.District.Name)).ReverseMap();
	}
}
