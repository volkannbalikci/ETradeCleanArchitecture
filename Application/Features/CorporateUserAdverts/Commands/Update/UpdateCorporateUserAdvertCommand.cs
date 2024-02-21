using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Commands.Update;

public class UpdateCorporateUserAdvertCommand : IRequest<UpdatedCorporateUserAdvertResponse>
{
    public Guid Id { get; set; }
    public Guid CorporateUserId { get; set; }
    public Guid AdvertId { get; set; }

    public class UpdateCorporateUserAdvertCommandHandler : IRequestHandler<UpdateCorporateUserAdvertCommand, UpdatedCorporateUserAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateUserAdvertRepository _corporateUserAdvertRepository;

        public UpdateCorporateUserAdvertCommandHandler(IMapper mapper, ICorporateUserAdvertRepository corporateUserAdvertRepository)
        {
            _mapper = mapper;
            _corporateUserAdvertRepository = corporateUserAdvertRepository;
        }

        public async Task<UpdatedCorporateUserAdvertResponse> Handle(UpdateCorporateUserAdvertCommand request, CancellationToken cancellationToken)
        {
            CorporateUserAdvert corporateUserAdvert = await _corporateUserAdvertRepository.GetAsync(c => c.Id == request.Id);
            corporateUserAdvert = _mapper.Map<CorporateUserAdvert>(request);
            await _corporateUserAdvertRepository.UpdateAsync(corporateUserAdvert);
            UpdatedCorporateUserAdvertResponse updatedCorporateUserAdvertResponse = _mapper.Map<UpdatedCorporateUserAdvertResponse>(corporateUserAdvert);
            return updatedCorporateUserAdvertResponse;
        }
    }
}
