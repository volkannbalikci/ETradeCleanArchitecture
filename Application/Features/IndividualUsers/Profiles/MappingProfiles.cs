using Application.Features.IndividualUsers.Commands.Create;
using Application.Features.IndividualUsers.Commands.Delete;
using Application.Features.IndividualUsers.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUsers.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<IndividualUser, CreateIndividualUserCommand>().ReverseMap();
		CreateMap<IndividualUser, CreatedIndividualUserResponse>().ReverseMap();
		CreateMap<IndividualUser, DeleteIndividualUserCommand>().ReverseMap();
		CreateMap<IndividualUser, DeletedIndividualUserResponse>().ReverseMap();
		CreateMap<IndividualUser, UpdateIndividualUserCommand>().ReverseMap();
		CreateMap<IndividualUser, UpdatedIndividualUserReponse>().ReverseMap();
	}
}
