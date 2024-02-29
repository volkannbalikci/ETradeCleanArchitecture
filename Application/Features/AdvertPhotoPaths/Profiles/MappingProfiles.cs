using Application.Features.AdvertPhotoPaths.Commands.Create;
using Application.Features.AdvertPhotoPaths.Commands.Delete;
using Application.Features.AdvertPhotoPaths.Commands.Update;
using Application.Features.AdvertPhotoPaths.Queries.GetById;
using Application.Features.AdvertPhotoPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdvertPhotoPaths.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<AdvertPhotoPath, CreateAdvertPhotoPathCommand>().ReverseMap();
		CreateMap<AdvertPhotoPath, CreatedAdvertPhotoPathResponse>().ReverseMap();
		CreateMap<AdvertPhotoPath, DeleteAdvertPhotoPathCommand>().ReverseMap();
		CreateMap<AdvertPhotoPath, DeletedAdvertPhotoPathResponse>().ReverseMap();
		CreateMap<AdvertPhotoPath, UpdateAdvertPhotoPathCommand>().ReverseMap();
		CreateMap<AdvertPhotoPath, UpdatedAdvertPhotoPathResponse>().ReverseMap();

		CreateMap<Paginate<AdvertPhotoPath>, GetListResponse<GetListAdvertPhotoPathListItemDto>>().ReverseMap();
		CreateMap<AdvertPhotoPath, GetListAdvertPhotoPathListItemDto>().ReverseMap();
		CreateMap<AdvertPhotoPath, GetByIdAdvertPhotoPathResponse>().ReverseMap();
	}
}
