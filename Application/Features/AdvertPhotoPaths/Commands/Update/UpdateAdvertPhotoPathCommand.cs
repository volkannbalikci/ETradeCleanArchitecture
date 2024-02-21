using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdvertPhotoPaths.Commands.Update;

public class UpdateAdvertPhotoPathCommand : IRequest<UpdatedAdvertPhotoPathResponse>
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }
    public DateOnly CreatedDate { get; set; }
    public DateOnly UpdatedDate { get; set; }

    public class UpdateAdvertPhotoPathCommandHandler : IRequestHandler<UpdateAdvertPhotoPathCommand, UpdatedAdvertPhotoPathResponse>
    {
        private readonly IAdvertPhotoPathRepository _advertPhotoPathRepository;
        private readonly IMapper _mapper;

        public UpdateAdvertPhotoPathCommandHandler(IAdvertPhotoPathRepository advertPhotoPathRepository, IMapper mapper)
        {
            _advertPhotoPathRepository = advertPhotoPathRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedAdvertPhotoPathResponse> Handle(UpdateAdvertPhotoPathCommand request, CancellationToken cancellationToken)
        {
            AdvertPhotoPath advertPhotoPath = await _advertPhotoPathRepository.GetAsync(ap => ap.Id == request.Id);
            advertPhotoPath = _mapper.Map<AdvertPhotoPath>(request);
            await _advertPhotoPathRepository.UpdateAsync(advertPhotoPath);
            UpdatedAdvertPhotoPathResponse updatedAdvertPhotoPathResponse = _mapper.Map<UpdatedAdvertPhotoPathResponse>(request);
            return updatedAdvertPhotoPathResponse;
        }
    }
}
