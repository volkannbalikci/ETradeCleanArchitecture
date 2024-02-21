using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Commands.Delete;

public class DeleteCorporateUserAdvertCommand : IRequest<DeletedCorporateUserAdvertResponse>
{
    public Guid Id { get; set; }

    public class DeleteCorporateUserAdvertCommandHandler : IRequestHandler<DeleteCorporateUserAdvertCommand, DeletedCorporateUserAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateUserAdvertRepository _corporateUserAdvertRepository;
        public async Task<DeletedCorporateUserAdvertResponse> Handle(DeleteCorporateUserAdvertCommand request, CancellationToken cancellationToken)
        {
            CorporateUserAdvert corporateUserAdvert = await _corporateUserAdvertRepository.GetAsync(c => c.Id == request.Id);
            await _corporateUserAdvertRepository.DeleteAsync(corporateUserAdvert);
            DeletedCorporateUserAdvertResponse deletedCorporateUserAdvertResponse = _mapper.Map<DeletedCorporateUserAdvertResponse>(corporateUserAdvert);
            return deletedCorporateUserAdvertResponse;
        }
    }
}
