using Application.Features.IndividualUserAdverts.Commands.Create;
using Application.Features.IndividualUserAdverts.Commands.Delete;
using Application.Features.IndividualUserAdverts.Commands.Update;
using AutoMapper;
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
		CreateMap<IndividualUserAdvert, DeleteIndividualUserAdverCommand>().ReverseMap();
		CreateMap<IndividualUserAdvert, DeletedIndividualUserAdverResponse>().ReverseMap();
		CreateMap<IndividualUserAdvert, UpdateIndividualUserAdvertCommand>().ReverseMap();
		CreateMap<IndividualUserAdvert, UpdatedIndividualUserAdvertResponse>().ReverseMap();
	}
}
