using Application.Features.CorporateUserAdverts.Commands.Create;
using Application.Features.CorporateUserAdverts.Commands.Delete;
using Application.Features.CorporateUserAdverts.Commands.Update;
using Application.Features.CorporateUserAdverts.Queries.GetById;
using Application.Features.CorporateUserAdverts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateUserAdvert, CreateCorporateUserAdvertCommand>().ReverseMap();
        CreateMap<CorporateUserAdvert, CreatedCorporateUserAdvertResponse>().ReverseMap();
        CreateMap<CorporateUserAdvert, DeleteCorporateUserAdvertCommand>().ReverseMap();
        CreateMap<CorporateUserAdvert, DeletedCorporateUserAdvertResponse>().ReverseMap();
        CreateMap<CorporateUserAdvert, UpdateCorporateUserAdvertCommand>().ReverseMap();
        CreateMap<CorporateUserAdvert, UpdatedCorporateUserAdvertResponse>().ReverseMap();

        CreateMap<Paginate<CorporateUserAdvert>, GetListResponse<GetListCorporateUserAdvertListItemDto>>().ReverseMap();

        CreateMap<CorporateUserAdvert, GetListCorporateUserAdvertListItemDto>()
            .ForMember(destinationMember: a => a.UserId, memberOptions: opt => opt.MapFrom(a => a.CorporateUser.UserId))
            .ForMember(destinationMember: a => a.CorporateUserCompanyName, memberOptions: opt => opt.MapFrom(a => a.CorporateUser.CompanyName))
            .ForMember(destinationMember: a => a.CorporateUserTaxIdentityNumber, memberOptions: opt => opt.MapFrom(a => a.CorporateUser.TaxIdentityNumber))
            .ForMember(destinationMember: a => a.AddressId, memberOptions: opt => opt.MapFrom(a => a.Advert.AddressId))
            .ForMember(destinationMember: a => a.IndividualUserId, memberOptions: opt => opt.MapFrom(a => a.Advert.IndividualUserId))
            .ForMember(destinationMember: a => a.ProductId, memberOptions: opt => opt.MapFrom(a => a.Advert.ProductId))
            .ForMember(destinationMember: a => a.AdvertPrice, memberOptions: opt => opt.MapFrom(a => a.Advert.Price))
            .ForMember(destinationMember: a => a.AdvertTitle, memberOptions: opt => opt.MapFrom(a => a.Advert.Title))
            .ForMember(destinationMember: a => a.AdvertDescription, memberOptions: opt => opt.MapFrom(a => a.Advert.Description))
            .ReverseMap();
        
        CreateMap<CorporateUserAdvert, GetByIdCorporateUserAdvertResponse>()
            .ForMember(destinationMember: a => a.UserId, memberOptions: opt => opt.MapFrom(a => a.CorporateUser.UserId))
            .ForMember(destinationMember: a => a.CorporateUserCompanyName, memberOptions: opt => opt.MapFrom(a => a.CorporateUser.CompanyName))
            .ForMember(destinationMember: a => a.CorporateUserTaxIdentityNumber, memberOptions: opt => opt.MapFrom(a => a.CorporateUser.TaxIdentityNumber))
            .ForMember(destinationMember: a => a.AddressId, memberOptions: opt => opt.MapFrom(a => a.Advert.AddressId))
            .ForMember(destinationMember: a => a.IndividualUserId, memberOptions: opt => opt.MapFrom(a => a.Advert.IndividualUserId))
            .ForMember(destinationMember: a => a.ProductId, memberOptions: opt => opt.MapFrom(a => a.Advert.ProductId))
            .ForMember(destinationMember: a => a.AdvertPrice, memberOptions: opt => opt.MapFrom(a => a.Advert.Price))
            .ForMember(destinationMember: a => a.AdvertTitle, memberOptions: opt => opt.MapFrom(a => a.Advert.Title))
            .ForMember(destinationMember: a => a.AdvertDescription, memberOptions: opt => opt.MapFrom(a => a.Advert.Description))
            .ReverseMap();
    }
}
