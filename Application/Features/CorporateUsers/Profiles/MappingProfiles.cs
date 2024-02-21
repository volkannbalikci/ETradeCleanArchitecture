using Application.Features.Addresses.Commands.Create;
using Application.Features.CorporateUsers.Commands.Create;
using Application.Features.CorporateUsers.Commands.Delete;
using Application.Features.CorporateUsers.Commands.Update;
using AutoMapper;
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
	}
}
