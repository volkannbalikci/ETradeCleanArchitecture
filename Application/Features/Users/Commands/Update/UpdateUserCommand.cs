using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Update;

public class UpdateUserCommand : IRequest<UpdatedUserResponse>
{
    public Guid Id { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UpdatedUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetAsync(u => u.Id == request.Id);
            user = _mapper.Map<User>(request);
            await _userRepository.UpdateAsync(user);
            UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(request);
            return updatedUserResponse;
        }
    }
}
