using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Commands.Create;

public class CreateIndividualUserAdvertCommand : IRequest<CreatedIndividualUserAdvertResponse>
{
    public Guid IndividulaUserId { get; set; }
    public Guid AdvertId { get; set; }

    public class CreateIndividualUserAdvertCommandHandler : IRequestHandler<CreateIndividualUserAdvertCommand, CreatedIndividualUserAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserAdvertRepository _ındividualUserAdvertRepository;

        public CreateIndividualUserAdvertCommandHandler(IMapper mapper, IIndividualUserAdvertRepository ındividualUserAdvertRepository)
        {
            _mapper = mapper;
            _ındividualUserAdvertRepository = ındividualUserAdvertRepository;
        }

        public async Task<CreatedIndividualUserAdvertResponse> Handle(CreateIndividualUserAdvertCommand request, CancellationToken cancellationToken)
        {
            IndividualUserAdvert individualUserAdvert = _mapper.Map<IndividualUserAdvert>(request);
            individualUserAdvert.Id = Guid.NewGuid();
            var result = await _ındividualUserAdvertRepository.AddAsync(individualUserAdvert);
            CreatedIndividualUserAdvertResponse createdIndividualUserAdvertResponse = _mapper.Map<CreatedIndividualUserAdvertResponse>(result);
            return createdIndividualUserAdvertResponse;
        }
    }
}
