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
		CreateMap<IndividualUser, CreateIndividualUserCommand>();
		CreateMap<IndividualUser, CreatedIndividualUserResponse>();
		CreateMap<IndividualUser, DeleteIndividualUserCommand>();
		CreateMap<IndividualUser, DeletedIndividualUserResponse>();
		CreateMap<IndividualUser, UpdateIndividualUserCommand>();
		CreateMap<IndividualUser, UpdatedIndividualUserReponse>();
	}
}
