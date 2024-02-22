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

namespace Application.Features.IndividualUserAdverts.Queries.GetList;

public class GetListIndividualUserAdvertQuery : IRequest<GetListResponse<GetListIndividualUserAdvertListItemDto>>
{
    public PageRequest pageRequest { get; set; }

    public class GetListIndividualUserQueryHandler : IRequestHandler<GetListIndividualUserAdvertQuery, GetListResponse<GetListIndividualUserAdvertListItemDto>>
    {
        private readonly IIndividualUserAdvertRepository _ındividualUserAdvertRepository;
        private readonly IMapper _mapper;

        public GetListIndividualUserQueryHandler(IIndividualUserAdvertRepository ındividualUserAdvertRepository, IMapper mapper)
        {
            _ındividualUserAdvertRepository = ındividualUserAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIndividualUserAdvertListItemDto>> Handle(GetListIndividualUserAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<IndividualUserAdvert> individualUserAdverts = await _ındividualUserAdvertRepository.GetListAsync(
                index: request.pageRequest.PageIndex,
                size: request.pageRequest.PageSize,
                include: i => i.Include(i => i.IndividualUser).Include(i => i.Advert)
                );
            GetListResponse<GetListIndividualUserAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListIndividualUserAdvertListItemDto>>(individualUserAdverts);
            return getListResponse;
        }
    }
}
