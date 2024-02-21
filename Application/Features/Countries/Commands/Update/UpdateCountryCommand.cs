using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands.Update;

public class UpdateCountryCommand : IRequest<UpdatedCountryResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }

    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, UpdatedCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public UpdateCountryCommandHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<UpdatedCountryResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = await _countryRepository.GetAsync(c => c.Id == request.Id);
            country = _mapper.Map<Country>(request);
            await _countryRepository.UpdateAsync(country);
            UpdatedCountryResponse updatedCountryResponse = _mapper.Map<UpdatedCountryResponse>(country);
            return updatedCountryResponse;
        }
    }
}
