using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetList;

public class GetListAddressQuery : IRequest<GetListResponse<GetListAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, GetListResponse<GetListAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAddressListItemDto>> Handle(GetListAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> addresses = await _addressRepository.GetListAsync(
                include: a => a.Include(a => a.Country).Include(a => a.City).Include(a => a.District),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListAddressListItemDto>>(addresses);
            return getListResponse;
        }
    }
}
