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

public class GetListCorporateUserAdvertQuery : IRequest<GetListResponse<GetListCortporateUserAdvertListItemDto>>
{
    public PageRequest pageRequest { get; set; }

    public class GetListCorporateUserAdvertQueryHandler : IRequestHandler<GetListCorporateUserAdvertQuery, GetListResponse<GetListCortporateUserAdvertListItemDto>>
    {
        private readonly ICorporateUserAdvertRepository _corporateUserAdvertRepository;
        private readonly IMapper _mapper;

        public GetListCorporateUserAdvertQueryHandler(ICorporateUserAdvertRepository corporateUserAdvertRepository, IMapper mapper)
        {
            _corporateUserAdvertRepository = corporateUserAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCortporateUserAdvertListItemDto>> Handle(GetListCorporateUserAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<CorporateUserAdvert> corporateUserAdverts = await _corporateUserAdvertRepository.GetListAsync(
                index: request.pageRequest.PageIndex,
                size: request.pageRequest.PageSize,
                include: c => c.Include(c => c.CorporateUser).Include(c => c.Advert)
                );
            GetListResponse<GetListCortporateUserAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCortporateUserAdvertListItemDto>>(corporateUserAdverts);
            return getListResponse;
        }
    }
}
