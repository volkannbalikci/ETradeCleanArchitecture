using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Delete
{
    public class DeleteCityCommand : IRequest<DeletedCityResponse>
    {
        public Guid Id { get; set; }

        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeletedCityResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICityRepository _cityRepository;

            public DeleteCityCommandHandler(IMapper mapper, ICityRepository cityRepository)
            {
                _mapper = mapper;
                _cityRepository = cityRepository;
            }

            public async Task<DeletedCityResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                City city = await _cityRepository.GetAsync(c => c.Id == request.Id);
                var result = await _cityRepository.DeleteAsync(city);
                DeletedCityResponse deletedCityResponse = _mapper.Map<DeletedCityResponse>(result);
                return deletedCityResponse;
            }
        }
    }
}
