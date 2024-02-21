using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualUsers.Commands.Create;

public class CreateIndividualUserCommand : IRequest<CreatedIndividualUserResponse>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public class CreateIndividualUserCommandHandler : IRequestHandler<CreateIndividualUserCommand, CreatedIndividualUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualUserRepository _ındividualUserRepository;

        public CreateIndividualUserCommandHandler(IMapper mapper, IIndividualUserRepository ındividualUserRepository)
        {
            _mapper = mapper;
            _ındividualUserRepository = ındividualUserRepository;
        }

        public async Task<CreatedIndividualUserResponse> Handle(CreateIndividualUserCommand request, CancellationToken cancellationToken)
        {
            IndividualUser individualUser = _mapper.Map<IndividualUser>(request);
            individualUser.Id = Guid.NewGuid();
            var result = await _ındividualUserRepository.AddAsync(individualUser);
            CreatedIndividualUserResponse createdIndividualUserResponse = _mapper.Map<CreatedIndividualUserResponse>(result);
            return createdIndividualUserResponse;
        }
    }
}
