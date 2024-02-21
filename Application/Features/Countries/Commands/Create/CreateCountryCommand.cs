using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands.Create;

public class CreateCountryCommand : IRequest<CreatedCountryResponse>
{
    public string Name { get; set; }
    public string ShortName { get; set; }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreatedCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CreateCountryCommandHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<CreatedCountryResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = _mapper.Map<Country>(request);
            country.Id = Guid.NewGuid();
            var result = await _countryRepository.AddAsync(country);
            CreatedCountryResponse createdCountryResponse = _mapper.Map<CreatedCountryResponse>(result);
            return createdCountryResponse;
        }
    }
}
