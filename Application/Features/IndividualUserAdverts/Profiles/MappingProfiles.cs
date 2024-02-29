using Application.Features.Admins.Queries.GetList;
using Application.Features.IndividualUserAdverts.Commands.Create;
using Application.Features.IndividualUserAdverts.Commands.Delete;
using Application.Features.IndividualUserAdverts.Commands.Update;
using Application.Features.IndividualUserAdverts.Queries.GetById;
using Application.Features.IndividualUserAdverts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<IndividualUserAdvert, CreateIndividualUserAdvertCommand>().ReverseMap();
		CreateMap<IndividualUserAdvert, CreatedIndividualUserAdvertResponse>().ReverseMap();
		CreateMap<IndividualUserAdvert, DeleteIndividualUserAdvertCommand>().ReverseMap();
		CreateMap<IndividualUserAdvert, DeletedIndividualUserAdvertResponse>().ReverseMap();
		CreateMap<IndividualUserAdvert, UpdateIndividualUserAdvertCommand>().ReverseMap();
		CreateMap<IndividualUserAdvert, UpdatedIndividualUserAdvertResponse>().ReverseMap();

		CreateMap<Paginate<IndividualUserAdvert>, GetListResponse<UpdatedIndividualUserAdvertResponse>>().ReverseMap();
        CreateMap<IndividualUserAdvert, GetListIndividualUserAdvertListItemDto>()
            .ForMember(destinationMember: a => a.AddressId, memberOptions: opt => opt.MapFrom(a => a.Advert.AddressId))
            .ForMember(destinationMember: a => a.IndividualUserId, memberOptions: opt => opt.MapFrom(a => a.Advert.IndividualUserId))
			.ForMember(destinationMember: a => a.ProductId, memberOptions: opt => opt.MapFrom(a => a.Advert.ProductId))
			.ForMember(destinationMember: a => a.AdvertPrice, memberOptions: opt => opt.MapFrom(a => a.Advert.Price))
			.ForMember(destinationMember: a => a.AdvertTitle, memberOptions: opt => opt.MapFrom(a => a.Advert.Title))
			.ForMember(destinationMember: a => a.AdvertDescription, memberOptions: opt => opt.MapFrom(a => a.Advert.Description))
			.ForMember(destinationMember: a => a.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.FirstName))
			.ForMember(destinationMember: a => a.IndividualUserLastName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.LastName))
			.ForMember(destinationMember: a => a.IndividualUserUserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
			.ForMember(destinationMember: a => a.IndividualUserEmail, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.Email)).ReverseMap();



        CreateMap<IndividualUserAdvert, GetByIdIndividualUserAdvertResponse>()
			.ForMember(destinationMember: a => a.AddressId, memberOptions: opt => opt.MapFrom(a => a.Advert.AddressId))
			.ForMember(destinationMember: a => a.IndividualUserId, memberOptions: opt => opt.MapFrom(a => a.Advert.IndividualUserId))
			.ForMember(destinationMember: a => a.ProductId, memberOptions: opt => opt.MapFrom(a => a.Advert.ProductId))
			.ForMember(destinationMember: a => a.AdvertPrice, memberOptions: opt => opt.MapFrom(a => a.Advert.Price))
			.ForMember(destinationMember: a => a.AdvertTitle, memberOptions: opt => opt.MapFrom(a => a.Advert.Title))
			.ForMember(destinationMember: a => a.AdvertDescription, memberOptions: opt => opt.MapFrom(a => a.Advert.Description))
			.ForMember(destinationMember: a => a.IndividualUserFirstName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.FirstName))
			.ForMember(destinationMember: a => a.IndividualUserLastName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.LastName))
			.ForMember(destinationMember: a => a.IndividualUserUserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
			.ForMember(destinationMember: a => a.IndividualUserEmail, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.Email)).ReverseMap();

    }
}
