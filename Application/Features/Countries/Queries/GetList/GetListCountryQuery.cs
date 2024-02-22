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

namespace Application.Features.Countries.Queries.GetList;

public class GetListCountryQuery : IRequest<GetListResponse<GetListCountryListItemDto>>
{
    public PageRequest pageRequest { get; set; }

    public class GetListCountryQueryHandler : IRequestHandler<GetListCountryQuery, GetListResponse<GetListCountryListItemDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetListCountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCountryListItemDto>> Handle(GetListCountryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Country> countries = await _countryRepository.GetListAsync(
                index: request.pageRequest.PageIndex,
                size: request.pageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCountryListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCountryListItemDto>>(countries);
            return getListResponse;
        }
    }
}
