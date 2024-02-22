using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateUserAdverts.Queries.GetById;

public class GetByIdCorporateUserAdvertQuery : IRequest<GetByIdCorporateUserAdvertResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCorporateUserAdvertQueryHandler : IRequestHandler<GetByIdCorporateUserAdvertQuery, GetByIdCorporateUserAdvertResponse>
    {
        private readonly ICorporateUserAdvertRepository _corporateUserAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdCorporateUserAdvertQueryHandler(ICorporateUserAdvertRepository corporateUserAdvertRepository, IMapper mapper)
        {
            _corporateUserAdvertRepository = corporateUserAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCorporateUserAdvertResponse> Handle(GetByIdCorporateUserAdvertQuery request, CancellationToken cancellationToken)
        {
            CorporateUserAdvert corporateUserAdvert = await _corporateUserAdvertRepository.GetAsync(
                predicate: c => c.Id == request.Id,
                include: c => c.Include(c => c.CorporateUser).Include(c => c.Advert)
                );
            GetByIdCorporateUserAdvertResponse getByIdCorporateUserAdvertResponse = _mapper.Map<GetByIdCorporateUserAdvertResponse>(corporateUserAdvert);
            return getByIdCorporateUserAdvertResponse;
        }
    }
}
