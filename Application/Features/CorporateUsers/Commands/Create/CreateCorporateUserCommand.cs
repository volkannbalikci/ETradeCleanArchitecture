using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUsers.Commands.Create;

public class CreateCorporateUserCommand : IRequest<CreatedCorporateUserResponse>
{
    public Guid UserId { get; set; }
    public string CompanyName { get; set; }
    public string TaxIdentityNumber { get; set; }

    public class CreateCorporateUserCommandHandler : IRequestHandler<CreateCorporateUserCommand, CreatedCorporateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateUserRepository _corporateUserRepository;

        public CreateCorporateUserCommandHandler(IMapper mapper, ICorporateUserRepository corporateUserRepository)
        {
            _mapper = mapper;
            _corporateUserRepository = corporateUserRepository;
        }

        public async Task<CreatedCorporateUserResponse> Handle(CreateCorporateUserCommand request, CancellationToken cancellationToken)
        {
            CorporateUser corporateUser = _mapper.Map<CorporateUser>(request);
            corporateUser.Id = Guid.NewGuid();
            var result = await _corporateUserRepository.AddAsync(corporateUser);
            CreatedCorporateUserResponse createdCorporateUserResponse = _mapper.Map<CreatedCorporateUserResponse>(result);
            return createdCorporateUserResponse;
        }
    }
}
