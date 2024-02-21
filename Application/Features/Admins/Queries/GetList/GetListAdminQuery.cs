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

namespace Application.Features.Admins.Queries.GetList;

public class GetListAdminQuery : IRequest<GetListResponse<GetListAdminListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, GetListResponse<GetListAdminListItemDto>>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetListAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdminListItemDto>> Handle(GetListAdminQuery request, CancellationToken cancellationToken)
        {
            Paginate<Admin> admins = await _adminRepository.GetListAsync(
                include: a => a.Include(a => a.IndividualUser),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
            GetListResponse<GetListAdminListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListAdminListItemDto>>(admins);
            return getListResponse;
        }
    }
}
