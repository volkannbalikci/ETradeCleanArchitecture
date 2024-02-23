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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressQuey : IRequest<GetListResponse<GetListUserAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserAddressQueyHandler : IRequestHandler<GetListUserAddressQuey, GetListResponse<GetListUserAddressListItemDto>>
    {
        public IUserAddressRepository _userAddressRepository { get; set; }
        public IMapper _mapper { get; set; }

        public GetListUserAddressQueyHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserAddressListItemDto>> Handle(GetListUserAddressQuey request, CancellationToken cancellationToken)
        {
            Paginate<UserAddress> userAddresses = await _userAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: u => u.Include(u => u.Addresses),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListUserAddressListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListUserAddressListItemDto>>(userAddresses);
            return getListResponse;
        }
    }
}
