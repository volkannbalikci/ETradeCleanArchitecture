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

public class DeleteIndividualUserAdverCommand : IRequest<DeletedIndividualUserAdverResponse>
{
    public Guid Id { get; set; }

    public class DeleteIndividualUserAdverCommandHandler : IRequestHandler<DeleteIndividualUserAdverCommand, DeletedIndividualUserAdverResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserAdvertRepository _ındividualUserAdvertRepository;

        public DeleteIndividualUserAdverCommandHandler(IMapper mapper, IIndividualUserAdvertRepository ındividualUserAdvertRepository)
        {
            _mapper = mapper;
            _ındividualUserAdvertRepository = ındividualUserAdvertRepository;
        }

        public async Task<DeletedIndividualUserAdverResponse> Handle(DeleteIndividualUserAdverCommand request, CancellationToken cancellationToken)
        {
            IndividualUserAdvert individualUserAdvert = await _ındividualUserAdvertRepository.GetAsync(i => i.Id == request.Id);
            await _ındividualUserAdvertRepository.DeleteAsync(individualUserAdvert);
            DeletedIndividualUserAdverResponse deletedIndividualUserAdverResponse = _mapper.Map<DeletedIndividualUserAdverResponse>(individualUserAdvert);
            return deletedIndividualUserAdverResponse;
        }
    }
}
