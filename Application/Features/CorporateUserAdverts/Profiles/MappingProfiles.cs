using Application.Features.CorporateUserAdverts.Commands.Create;
using Application.Features.CorporateUserAdverts.Commands.Delete;
using Application.Features.CorporateUserAdverts.Commands.Update;
using AutoMapper;
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
	}
}
