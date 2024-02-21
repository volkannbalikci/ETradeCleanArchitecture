using Application.Features.Categories.Commands.Create;
using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Country, CreateCountryCommand>().ReverseMap();
		CreateMap<Country, CreatedCountryResponse>().ReverseMap();
		CreateMap<Country, DeleteCountryCommand>().ReverseMap();
		CreateMap<Country, DeletedCountryResponse>().ReverseMap();
		CreateMap<Country, UpdateCountryCommand>().ReverseMap();
		CreateMap<Country, UpdatedCountryResponse>().ReverseMap();
	}
}
