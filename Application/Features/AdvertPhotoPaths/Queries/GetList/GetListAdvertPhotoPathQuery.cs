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

namespace Application.Features.AdvertPhotoPaths.Queries.GetList;

public class GetListAdvertPhotoPathQuery : IRequest<GetListResponse<GetListAdvertPhotoPathListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdvertPhotoPathQueryHandler : IRequestHandler<GetListAdvertPhotoPathQuery, GetListResponse<GetListAdvertPhotoPathListItemDto>>
    {
        private readonly IAdvertPhotoPathRepository _advertPhotoPathRepository;
        private readonly IMapper _mapper;

        public GetListAdvertPhotoPathQueryHandler(IAdvertPhotoPathRepository advertPhotoPathRepository, IMapper mapper)
        {
            _advertPhotoPathRepository = advertPhotoPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertPhotoPathListItemDto>> Handle(GetListAdvertPhotoPathQuery request, CancellationToken cancellationToken)
        {
            Paginate<AdvertPhotoPath> advertPhotoPaths = await _advertPhotoPathRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListAdvertPhotoPathListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListAdvertPhotoPathListItemDto>>(advertPhotoPaths);
            return getListResponse;
        }
    }
}
