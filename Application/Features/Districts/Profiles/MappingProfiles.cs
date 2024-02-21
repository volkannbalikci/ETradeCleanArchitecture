using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Districts.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<District, CreateDistrictCommand>().ReverseMap();
		CreateMap<District, CreatedDistrictResponse>().ReverseMap();
		CreateMap<District, DeleteDistrictCommand>().ReverseMap();
		CreateMap<District, DeletedDistrictResponse>().ReverseMap();
		CreateMap<District, UpdateDistrictCommand>().ReverseMap();
		CreateMap<District, UpdatedDistrictResponse>().ReverseMap();
	}
}
