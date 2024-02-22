using Application.Features.Admins.Queries.GetById;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Product, CreateProductCommand>().ReverseMap();
		CreateMap<Product, CreatedProductResponse>().ReverseMap();
		CreateMap<Product, DeleteProductCommand>().ReverseMap();
		CreateMap<Product, DeletedProductResponse>().ReverseMap();
		CreateMap<Product, UpdateProductCommand>().ReverseMap();
		CreateMap<Product, UpdatedProductResponse>().ReverseMap();

		CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();
		CreateMap<Product, GetListProductListItemDto>()
			.ForMember(destinationMember: p => p.ProductId, memberOptions: opt => opt.MapFrom(p => p.Id))
			.ForMember(destinationMember: p => p.ProductName, memberOptions: opt => opt.MapFrom(p => p.Name))
			.ForMember(destinationMember: p => p.BrandId, memberOptions: opt => opt.MapFrom(p => p.Brand.Id))
			.ForMember(destinationMember: p => p.BrandName, memberOptions: opt => opt.MapFrom(p => p.Brand.Name))
			.ForMember(destinationMember: p => p.BrandWebsiteUrl, memberOptions: opt => opt.MapFrom(p => p.Brand.WebsiteUrl))
			.ForMember(destinationMember: p => p.CategoryId, memberOptions: opt => opt.MapFrom(p => p.Category.Id))
			.ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name))
			.ForMember(destinationMember: p => p.CategoryDescription, memberOptions: opt => opt.MapFrom(p => p.Category.Description))
			.ForMember(destinationMember: p => p.CategoryDescription, memberOptions: opt => opt.MapFrom(p => p.Category.Description)).ReverseMap();

		CreateMap<Product, GetByIdProductResponse>()
            .ForMember(destinationMember: p => p.ProductId, memberOptions: opt => opt.MapFrom(p => p.Id))
            .ForMember(destinationMember: p => p.ProductName, memberOptions: opt => opt.MapFrom(p => p.Name))
            .ForMember(destinationMember: p => p.BrandId, memberOptions: opt => opt.MapFrom(p => p.Brand.Id))
            .ForMember(destinationMember: p => p.BrandName, memberOptions: opt => opt.MapFrom(p => p.Brand.Name))
            .ForMember(destinationMember: p => p.BrandWebsiteUrl, memberOptions: opt => opt.MapFrom(p => p.Brand.WebsiteUrl))
            .ForMember(destinationMember: p => p.CategoryId, memberOptions: opt => opt.MapFrom(p => p.Category.Id))
            .ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name))
            .ForMember(destinationMember: p => p.CategoryDescription, memberOptions: opt => opt.MapFrom(p => p.Category.Description))
            .ForMember(destinationMember: p => p.CategoryDescription, memberOptions: opt => opt.MapFrom(p => p.Category.Description)).ReverseMap();

    }
}
