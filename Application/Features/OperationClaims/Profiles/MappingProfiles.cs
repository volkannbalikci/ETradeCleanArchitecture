using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Commands.Delete;
using Application.Features.OperationClaims.Commands.Update;
using Application.Features.OperationClaims.Queries.GetById;
using Application.Features.OperationClaims.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>();

        CreateMap<Paginate<OperationClaim>, GetListResponse<GetListOperationClaimListItemDto>>().ReverseMap();
        CreateMap<OperationClaim, GetListOperationClaimListItemDto>()
            .ForMember(destinationMember: o => o.OperationClaimName, memberOptions: opt => opt.MapFrom(o => o.Name)).ReverseMap();

        CreateMap<OperationClaim, GetByIdOpereationClaimResponse>()
            .ForMember(destinationMember: o => o.OperationClaimName, memberOptions: opt => opt.MapFrom(o => o.Name)).ReverseMap();

    }
}
