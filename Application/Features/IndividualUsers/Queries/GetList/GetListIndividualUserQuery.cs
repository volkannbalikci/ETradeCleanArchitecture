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

namespace Application.Features.IndividualUsers.Queries.GetList;

public class GetListIndividualUserQuery : IRequest<GetListResponse<GetListIndividualUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListIndividualUserQueryHandler : IRequestHandler<GetListIndividualUserQuery, GetListResponse<GetListIndividualUserListItemDto>>
    {
        private readonly IIndividualUserRepository _individualUserRepository;
        private readonly IMapper _mapper;

        public GetListIndividualUserQueryHandler(IIndividualUserRepository individualUserRepository, IMapper mapper)
        {
            _individualUserRepository = individualUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIndividualUserListItemDto>> Handle(GetListIndividualUserQuery request, CancellationToken cancellationToken)
        {
            Paginate<IndividualUser> individualUsers = await _individualUserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListIndividualUserListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListIndividualUserListItemDto>>(individualUsers);
            return getListResponse;
        }
    }
}
