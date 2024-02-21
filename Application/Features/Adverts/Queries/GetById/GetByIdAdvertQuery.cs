﻿using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Queries.GetById;

public class GetByIdAdvertQuery : IRequest<GetByIdAdvertResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdvertQueryHandler : IRequestHandler<GetByIdAdvertQuery, GetByIdAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;

        public GetByIdAdvertQueryHandler(IMapper mapper, IAdvertRepository advertRepository)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
        }

        public async Task<GetByIdAdvertResponse> Handle(GetByIdAdvertQuery request, CancellationToken cancellationToken)
        {
            Advert advert = await _advertRepository.GetAsync(
                predicate: a => a.Id == request.Id, 
                include:
                 a => a
                .Include(a => a.Address.Country)
                .Include(a => a.Address.City)
                .Include(a => a.Address.District)
                .Include(a => a.IndividualUser)
                .Include(a => a.Product.Brand)
                .Include(a => a.Product.Category)
                 );
            GetByIdAdvertQuery getByIdAdvertQuery = _mapper.Map<GetByIdAdvertQuery>(advert);
            GetByIdAdvertResponse getByIdAdvertResponse = _mapper.Map<GetByIdAdvertResponse>(getByIdAdvertQuery);
            return getByIdAdvertResponse;
        }
    }
}
