using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Delete;

public class DeleteAddressCommand : IRequest<DeletedAddressResponse>
{
    public Guid Id { get; set; }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeletedAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<DeletedAddressResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = await _addressRepository.GetAsync(a => a.Id == request.Id);
            await _addressRepository.DeleteAsync(address);
            DeletedAddressResponse deletedAddressResponse = _mapper.Map<DeletedAddressResponse>(address);
            return deletedAddressResponse;
        }
    }
}
