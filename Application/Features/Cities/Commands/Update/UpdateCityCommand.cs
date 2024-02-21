using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Update;

public class UpdateCityCommand : IRequest<UpdatedCityResponse>
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdatedCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public UpdateCityCommandHandler(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<UpdatedCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City city = await _cityRepository.GetAsync(c => c.Id == request.Id);
            city = _mapper.Map<City>(request);
            await _cityRepository.UpdateAsync(city);
            UpdatedCityResponse updatedCityResponse = _mapper.Map<UpdatedCityResponse>(city);
            return updatedCityResponse;
        }
    }
}
