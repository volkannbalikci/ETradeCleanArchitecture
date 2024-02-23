using Application.Features.Commands.Create;
using Application.Features.UserAddresses.Commands.Create;
using Application.Features.UserAddresses.Commands.Delete;
using Application.Features.UserAddresses.Commands.Update;
using Application.Features.UserAddresses.Queries.GetById;
using Application.Features.UserAddresses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
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
		CreateMap<UserAddress, CreateUserAddressCommand>().ReverseMap();
		CreateMap<UserAddress, CreatedUserAddressResponse>().ReverseMap();
		CreateMap<UserAddress, DeleteUserAddressCommand>().ReverseMap();
		CreateMap<UserAddress, DeletedUserAddressResponse>().ReverseMap();
		CreateMap<UserAddress, UpdateUserAddressCommand>().ReverseMap();
		CreateMap<UserAddress, UpdatedUserAddressResponse>().ReverseMap();

		CreateMap<Paginate<UserAddress>, GetListResponse<GetListUserAddressListItemDto>>().ReverseMap();
		CreateMap<UserAddress, GetListUserAddressListItemDto>()
			.ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.Id))
			.ForMember(destinationMember: u => u.CountryId, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().CountryId))
			.ForMember(destinationMember: u => u.CityId, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().CityId))
			.ForMember(destinationMember: u => u.DistrictId, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().DistrictId))
			.ForMember(destinationMember: u => u.AddressPostalCode, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().PostalCode))
			.ForMember(destinationMember: u => u.AddressDetails, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().AddressDetails))
			.ForMember(destinationMember: u => u.UserAddressIsMain, memberOptions: opt => opt.MapFrom(u => u.IsMain)).ReverseMap();
		
		CreateMap<UserAddress, GetByIdUserAddressResponse>()
			.ForMember(destinationMember: u => u.UserId, memberOptions: opt => opt.MapFrom(u => u.Id))
			.ForMember(destinationMember: u => u.CountryId, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().CountryId))
			.ForMember(destinationMember: u => u.CityId, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().CityId))
			.ForMember(destinationMember: u => u.DistrictId, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().DistrictId))
			.ForMember(destinationMember: u => u.AddressPostalCode, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().PostalCode))
			.ForMember(destinationMember: u => u.AddressDetails, memberOptions: opt => opt.MapFrom(u => u.Addresses.FirstOrDefault().AddressDetails))
			.ForMember(destinationMember: u => u.UserAddressIsMain, memberOptions: opt => opt.MapFrom(u => u.IsMain)).ReverseMap();
	}
}
