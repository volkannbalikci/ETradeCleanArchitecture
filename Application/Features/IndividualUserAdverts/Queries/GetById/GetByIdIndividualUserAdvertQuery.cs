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

namespace Application.Features.IndividualUserAdverts.Queries.GetById;

public class GetByIdIndividualUserAdvertQuery : IRequest<GetByIdIndividualUserAdvertResponse>
{
    public Guid Id { get; set; }

    public class GetByIdIndividualUserAdvertQueryHandler : IRequestHandler<GetByIdIndividualUserAdvertQuery, GetByIdIndividualUserAdvertResponse>
    {
        private readonly IIndividualUserAdvertRepository _ındividualUserAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdIndividualUserAdvertQueryHandler(IIndividualUserAdvertRepository ındividualUserAdvertRepository, IMapper mapper)
        {
            _ındividualUserAdvertRepository = ındividualUserAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdIndividualUserAdvertResponse> Handle(GetByIdIndividualUserAdvertQuery request, CancellationToken cancellationToken)
        {
            IndividualUserAdvert individualUserAdvert = await _ındividualUserAdvertRepository.GetAsync(
                predicate: i => i.Id == request.Id,
                include: i => i.Include(i => i.IndividualUser).Include(i => i.Advert)
                );
            GetByIdIndividualUserAdvertResponse getByIdIndividualUserAdvertResponse = _mapper.Map<GetByIdIndividualUserAdvertResponse>(individualUserAdvert);
            return getByIdIndividualUserAdvertResponse;
        }
    }
}
