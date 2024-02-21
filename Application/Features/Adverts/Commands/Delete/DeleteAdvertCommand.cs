using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Commands.Delete;

public class DeleteAdvertCommand : IRequest<DeletedAdvertResponse>
{
    public Guid Id { get; set; }

    public class DeleteAdvertCommandHandler : IRequestHandler<DeleteAdvertCommand, DeletedAdvertResponse>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteAdvertCommandHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<DeletedAdvertResponse> Handle(DeleteAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = await _advertRepository.GetAsync(a => a.Id == request.Id);
            await _advertRepository.DeleteAsync(advert);
            DeletedAdvertResponse deletedAdvertResponse = _mapper.Map<DeletedAdvertResponse>(advert);
            return deletedAdvertResponse;
        }
    }
}
