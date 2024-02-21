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

namespace Application.Features.Adverts.Queries.GetList;

public class GetListAdvertQuery : IRequest<GetListResponse<GetListAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdvertQueryHandler : IRequestHandler<GetListAdvertQuery, GetListResponse<GetListAdvertListItemDto>>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public GetListAdvertQueryHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertListItemDto>> Handle(GetListAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<Advert> adverts = await _advertRepository.GetListAsync(
                include: a => a
                .Include(a => a.Address.Country)
                .Include(a => a.Address.City)
                .Include(a => a.Address.District)
                .Include(a => a.IndividualUser)
                .Include(a => a.Product.Brand)
                .Include(a => a.Product.Category),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListAdvertListItemDto>>(adverts);
            return getListResponse;
        }
    }
}
