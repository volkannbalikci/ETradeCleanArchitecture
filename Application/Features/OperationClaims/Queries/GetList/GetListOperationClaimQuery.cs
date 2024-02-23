using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetList;

public class GetListOperationClaimQuery : IRequest<GetListResponse<GetListOperationClaimListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, GetListResponse<GetListOperationClaimListItemDto>>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOperationClaimListItemDto>> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            Paginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListOperationClaimListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListOperationClaimListItemDto>>(operationClaims);
            return getListResponse;
        }
    }
}
