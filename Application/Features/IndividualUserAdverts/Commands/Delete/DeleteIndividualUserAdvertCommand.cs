using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUserAdverts.Commands.Delete;

public class DeleteIndividualUserAdvertCommand : IRequest<DeletedIndividualUserAdvertResponse>
{
    public Guid Id { get; set; }

    public class DeleteIndividualUserAdverCommandHandler : IRequestHandler<DeleteIndividualUserAdvertCommand, DeletedIndividualUserAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserAdvertRepository _ındividualUserAdvertRepository;

        public DeleteIndividualUserAdverCommandHandler(IMapper mapper, IIndividualUserAdvertRepository ındividualUserAdvertRepository)
        {
            _mapper = mapper;
            _ındividualUserAdvertRepository = ındividualUserAdvertRepository;
        }

        public async Task<DeletedIndividualUserAdvertResponse> Handle(DeleteIndividualUserAdvertCommand request, CancellationToken cancellationToken)
        {
            IndividualUserAdvert individualUserAdvert = await _ındividualUserAdvertRepository.GetAsync(i => i.Id == request.Id);
            await _ındividualUserAdvertRepository.DeleteAsync(individualUserAdvert);
            DeletedIndividualUserAdvertResponse deletedIndividualUserAdverResponse = _mapper.Map<DeletedIndividualUserAdvertResponse>(individualUserAdvert);
            return deletedIndividualUserAdverResponse;
        }
    }
}
