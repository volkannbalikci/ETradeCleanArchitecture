using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdvertPhotoPaths.Commands.Delete;

public class DeleteAdvertPhotoPathCommand : IRequest<DeletedAdvertPhotoPathResponse>
{
    public Guid Id { get; set; }

    public class DeleteAdvertPhotoPathHandler : IRequestHandler<DeleteAdvertPhotoPathCommand, DeletedAdvertPhotoPathResponse>
    {
        private readonly IAdvertPhotoPathRepository _advertPhotoPathRepository;
        private readonly IMapper _mapper;

        public DeleteAdvertPhotoPathHandler(IAdvertPhotoPathRepository advertPhotoPathRepository, IMapper mapper)
        {
            _advertPhotoPathRepository = advertPhotoPathRepository;
            _mapper = mapper;
        }

        public async Task<DeletedAdvertPhotoPathResponse> Handle(DeleteAdvertPhotoPathCommand request, CancellationToken cancellationToken)
        {
            AdvertPhotoPath advertPhotoPath = await _advertPhotoPathRepository.GetAsync(ap => ap.Id == request.Id);
            await _advertPhotoPathRepository.DeleteAsync(advertPhotoPath);
            DeletedAdvertPhotoPathResponse deletedAdvertPhotoPathResponse = _mapper.Map<DeletedAdvertPhotoPathResponse>(advertPhotoPath);
            return deletedAdvertPhotoPathResponse;
        }
    }
}
