using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommand : IRequest<CreatedCityResponse>
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public class CreateCityCommandHadnler : IRequestHandler<CreateCityCommand, CreatedCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public CreateCityCommandHadnler(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<CreatedCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<City>(request);
            city.Id = Guid.NewGuid(); 
            var result = await _cityRepository.AddAsync(city);
            CreatedCityResponse createdCityResponse = _mapper.Map<CreatedCityResponse>(result);
            return createdCityResponse;
        }
    }
}
