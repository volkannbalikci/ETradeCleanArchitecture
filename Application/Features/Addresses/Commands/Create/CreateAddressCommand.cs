using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommand : IRequest<CreatedAddressResponse>
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            address.Id = Guid.NewGuid();
            var result = await _addressRepository.AddAsync(address);
            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(result);
            return createdAddressResponse;
        }
    }
}
