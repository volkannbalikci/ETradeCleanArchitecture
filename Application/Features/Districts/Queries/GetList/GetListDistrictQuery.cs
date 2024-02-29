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

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictQuery : IRequest<GetListResponse<GetListDistrictListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDistrictQueryHandler : IRequestHandler<GetListDistrictQuery, GetListResponse<GetListDistrictListItemDto>>
{
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetListDistrictQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDistrictListItemDto>> Handle(GetListDistrictQuery request, CancellationToken cancellationToken)
        {
            Paginate<District> districts = await _districtRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );   
            GetListResponse<GetListDistrictListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListDistrictListItemDto>>(districts);
            return getListResponse;
        }
    }
}
