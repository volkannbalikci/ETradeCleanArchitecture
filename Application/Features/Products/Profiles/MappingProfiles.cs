using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using AutoMapper;
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
		CreateMap<Product, CreateProductCommand>();
		CreateMap<Product, CreatedProductResponse>();
		CreateMap<Product, DeleteProductCommand>();
		CreateMap<Product, DeletedProductResponse>();
		CreateMap<Product, UpdateProductCommand>();
		CreateMap<Product, UpdatedProductResponse>();
	}
}
