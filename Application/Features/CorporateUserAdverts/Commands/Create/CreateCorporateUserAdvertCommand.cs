using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Commands.Create;

public class CreateCorporateUserAdvertCommand : IRequest<CreatedCorporateUserAdvertResponse>
{
    public Guid CorporateUserId { get; set; }
    public Guid AdvertId { get; set; }

    public class CreateCorporateUserAdvertCommandHandler : IRequestHandler<CreateCorporateUserAdvertCommand, CreatedCorporateUserAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateUserAdvertRepository _corporateUserAdvertRepository;

        public CreateCorporateUserAdvertCommandHandler(IMapper mapper, ICorporateUserAdvertRepository corporateUserAdvertRepository)
        {
            _mapper = mapper;
            _corporateUserAdvertRepository = corporateUserAdvertRepository;
        }

        public async Task<CreatedCorporateUserAdvertResponse> Handle(CreateCorporateUserAdvertCommand request, CancellationToken cancellationToken)
        {
            CorporateUserAdvert corporateUserAdvert = _mapper.Map<CorporateUserAdvert>(request);
            corporateUserAdvert.Id = Guid.NewGuid();
            var result = await _corporateUserAdvertRepository.AddAsync(corporateUserAdvert);
            CreatedCorporateUserAdvertResponse createdCorporateUserAdvertResponse = _mapper.Map<CreatedCorporateUserAdvertResponse>(result);
            return createdCorporateUserAdvertResponse;
        }
    }
}
