using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Update;

public class UpdateAdminCommand : IRequest<UpdatedAdminResponse>
{
    public Guid Id { get; set; }
    public Guid IndividualUserId { get; set; }
    public string RegisterNumber { get; set; }

    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdatedAdminResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;

        public UpdateAdminCommandHandler(IMapper mapper, IAdminRepository adminRepository)
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
        }

        public async Task<UpdatedAdminResponse> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin admin = await _adminRepository.GetAsync(a => a.Id == request.Id);
            admin = _mapper.Map(request, admin);
            await _adminRepository.UpdateAsync(admin);
            UpdatedAdminResponse updatedAdminResponse = _mapper.Map<UpdatedAdminResponse>(admin);
            return updatedAdminResponse;
        }
    }
}
