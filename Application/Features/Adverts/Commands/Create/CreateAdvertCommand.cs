using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Commands.Create;

public class CreateAdvertCommand : IRequest<CreatedAdvertResposne>
{
    public Guid AddressId { get; set; }
    public Guid IndividualUserId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }

    public class CreateAdvertCommandHandler : IRequestHandler<CreateAdvertCommand, CreatedAdvertResposne>
    {
        private readonly IAdvertRepository _advertRespository;
        private readonly IMapper _mapper;

        public CreateAdvertCommandHandler(IAdvertRepository advertRespository, IMapper mapper)
        {
            _advertRespository = advertRespository;
            _mapper = mapper;
        }

        public async Task<CreatedAdvertResposne> Handle(CreateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            var result = await _advertRespository.AddAsync(advert);
            CreatedAdvertResposne createdAdvertResposne = _mapper.Map<CreatedAdvertResposne>(result);
            return createdAdvertResposne;
        }
    }
}
