using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Queries.GetList;
using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Delete;
using Application.Features.Admins.Commands.Update;
using Application.Features.Admins.Queries.GetById;
using Application.Features.Admins.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Admin, CreateAdminCommand>().ReverseMap();
		CreateMap<Admin, CreatedAdminResponse>().ReverseMap();
		CreateMap<Admin, DeleteAdminCommand>().ReverseMap();
		CreateMap<Admin, DeletedAdminResponse>().ReverseMap();
		CreateMap<Admin, UpdateAdminCommand>().ReverseMap();
		CreateMap<Admin, UpdatedAdminResponse>().ReverseMap();

		CreateMap<Paginate<Admin>, GetListResponse<GetListAdminListItemDto>>().ReverseMap();
		CreateMap<Admin, GetListAdminListItemDto>()
			.ForMember(destinationMember: a => a.FirstName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.FirstName))
			.ForMember(destinationMember: a => a.LastName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.LastName))
			.ForMember(destinationMember: a => a.UserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
			.ForMember(destinationMember: a => a.Email, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.Email))
			.ReverseMap();
		
		CreateMap<Admin, GetByIdAdminResponse>()
			.ForMember(destinationMember: a => a.FirstName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.FirstName))
			.ForMember(destinationMember: a => a.LastName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.LastName))
			.ForMember(destinationMember: a => a.UserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
			.ForMember(destinationMember: a => a.Email, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.Email))
			.ReverseMap();
	}
}
