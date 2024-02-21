using Application.Features.UserAddresses.Commands.Create;
using Application.Services.Repositories;
using Domain.Entities;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Create
{
    public class CreateUserAddressCommand : IRequest<CreatedUserAddressResponse>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public bool IsMain { get; set; }

        public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, CreatedUserAddressResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserAddressRepository _userAddressRepository;

            public CreateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository)
            {
                _mapper = mapper;
                _userAddressRepository = userAddressRepository;
            }

            public async Task<CreatedUserAddressResponse> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
            {
                UserAddress userAddress = _mapper.Map<UserAddress>(request);
                userAddress.Id = Guid.NewGuid();
                var result = await _userAddressRepository.AddAsync(userAddress);
                CreatedUserAddressResponse createdUserAddressResponse = _mapper.Map<CreatedUserAddressResponse>(result);
                return createdUserAddressResponse;
            }
        }
    }
}
