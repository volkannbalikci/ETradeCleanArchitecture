using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Commands.Delete;
using Application.Features.Adverts.Commands.Update;
using Application.Features.Adverts.Queries.GetById;
using Application.Features.Adverts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;

namespace Application.Features.Adverts.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Advert, CreateAdvertCommand>().ReverseMap();
		CreateMap<Advert, CreatedAdvertResposne>().ReverseMap();
		CreateMap<Advert, DeleteAdvertCommand>().ReverseMap();
		CreateMap<Advert, DeletedAdvertResponse>().ReverseMap();
		CreateMap<Advert, UpdateAdvertCommand>().ReverseMap();
		CreateMap<Advert, UpdatedAdvertResponse>().ReverseMap();

		CreateMap<Paginate<Advert>, GetListResponse<GetListAdvertListItemDto>>().ReverseMap();
		CreateMap<Advert, GetListAdvertListItemDto>()
			.ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Address.Country.Name))
			.ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.Address.City.Name))
			.ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.Address.District.Name))
			.ForMember(destinationMember: a => a.UserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
			.ForMember(destinationMember: a => a.ProductName, memberOptions: opt => opt.MapFrom(a => a.Product.Name))
			.ForMember(destinationMember: a => a.BrandName, memberOptions: opt => opt.MapFrom(a => a.Product.Brand.Name))
			.ForMember(destinationMember: a => a.CategoryName, memberOptions: opt => opt.MapFrom(a => a.Product.Category.Name)).ReverseMap();	
		
		CreateMap<Advert, GetByIdAdvertResponse>()
			.ForMember(destinationMember: a => a.CountryName, memberOptions: opt => opt.MapFrom(a => a.Address.Country.Name))
			.ForMember(destinationMember: a => a.CityName, memberOptions: opt => opt.MapFrom(a => a.Address.City.Name))
			.ForMember(destinationMember: a => a.DistrictName, memberOptions: opt => opt.MapFrom(a => a.Address.District.Name))
			.ForMember(destinationMember: a => a.UserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
			.ForMember(destinationMember: a => a.ProductName, memberOptions: opt => opt.MapFrom(a => a.Product.Name))
			.ForMember(destinationMember: a => a.BrandName, memberOptions: opt => opt.MapFrom(a => a.Product.Brand.Name))
			.ForMember(destinationMember: a => a.CategoryName, memberOptions: opt => opt.MapFrom(a => a.Product.Category.Name)).ReverseMap();
	}
}
