using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Commands.Update;

public class UpdateIndividualUserAdvertCommand : IRequest<UpdatedIndividualUserAdvertResponse>
{
    public Guid Id { get; set; }
    public Guid IndividulaUserId { get; set; }
    public Guid AdvertId { get; set; }

    public class UpdateIndividualUserAdvertCommandHandler : IRequestHandler<UpdateIndividualUserAdvertCommand, UpdatedIndividualUserAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserAdvertRepository _ındividualUserAdvertRepository;

        public UpdateIndividualUserAdvertCommandHandler(IMapper mapper, IIndividualUserAdvertRepository ındividualUserAdvertRepository)
        {
            _mapper = mapper;
            _ındividualUserAdvertRepository = ındividualUserAdvertRepository;
        }

        public async Task<UpdatedIndividualUserAdvertResponse> Handle(UpdateIndividualUserAdvertCommand request, CancellationToken cancellationToken)
        {
            IndividualUserAdvert individualUserAdvert = await _ındividualUserAdvertRepository.GetAsync(i => i.Id == request.Id);
            individualUserAdvert = _mapper.Map<IndividualUserAdvert>(request);
            UpdatedIndividualUserAdvertResponse updatedIndividualUserAdvertResponse = _mapper.Map<UpdatedIndividualUserAdvertResponse>(individualUserAdvert);
            return updatedIndividualUserAdvertResponse;
        }
    }
}
