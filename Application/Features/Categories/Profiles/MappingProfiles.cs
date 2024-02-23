using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
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
		CreateMap<Category, CreateCategoryCommand>().ReverseMap();
		CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
		CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
		CreateMap<Category, DeletedCategoryResponse>().ReverseMap();
		CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
		CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

		CreateMap<Paginate<Category>, GetListResponse<GetListCategoryListItemDto>>().ReverseMap();
	}
}
