using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Create;

public class CreateAdminCommand : IRequest<CreatedAdminResponse>
{
    public Guid IndividulaUserId { get; set; }

    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreatedAdminResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;
        public CreateAdminCommandHandler(IMapper mapper, IAdminRepository adminRepository)
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
        }

        public async Task<CreatedAdminResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin admin = _mapper.Map<Admin>(request);
            admin.Id = Guid.NewGuid();
            var result = await _adminRepository.AddAsync(admin);
            CreatedAdminResponse createdAdminResponse = _mapper.Map<CreatedAdminResponse>(result);
            return createdAdminResponse;
        }
    }
}
