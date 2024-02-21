using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Category, CreateCategoryCommand>();
		CreateMap<Category, CreatedCategoryResponse>();
		CreateMap<Category, DeleteCategoryCommand>();
		CreateMap<Category, DeletedCategoryResponse>();
		CreateMap<Category, UpdateCategoryCommand>();
		CreateMap<Category, UpdatedCategoryResponse>();
	}
}
