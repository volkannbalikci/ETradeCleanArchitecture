using Application.Features.Admins.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Commands.Delete;

public class DeleteAdminCommand : IRequest<DeletedAdminResponse>
{
    public Guid Id { get; set; }

    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, DeletedAdminResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;

        public DeleteAdminCommandHandler(IMapper mapper, IAdminRepository adminRepository)
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
        }

        public async Task<DeletedAdminResponse> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _adminRepository.GetAsync(a => a.Id == request.Id);
            await _adminRepository.DeleteAsync(admin);
            DeletedAdminResponse deletedAdminResponse = _mapper.Map<DeletedAdminResponse>(admin);
            return deletedAdminResponse;
        }
    }
}
