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

namespace Application.Features.CorporateUserAdverts.Queries.GetList;

public class GetListCorporateUserAdvertQuery : IRequest<GetListResponse<GetListCorporateUserAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCorporateUserAdvertQueryHandler : IRequestHandler<GetListCorporateUserAdvertQuery, GetListResponse<GetListCorporateUserAdvertListItemDto>>
    {
        private readonly ICorporateUserAdvertRepository _corporateUserAdvertRepository;
        private readonly IMapper _mapper;

        public GetListCorporateUserAdvertQueryHandler(ICorporateUserAdvertRepository corporateUserAdvertRepository, IMapper mapper)
        {
            _corporateUserAdvertRepository = corporateUserAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCorporateUserAdvertListItemDto>> Handle(GetListCorporateUserAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<CorporateUserAdvert> corporateUserAdverts = await _corporateUserAdvertRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.CorporateUser).Include(c => c.Advert)
                );
            GetListResponse<GetListCorporateUserAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCorporateUserAdvertListItemDto>>(corporateUserAdverts);
            return getListResponse;
        }
    }
}
