using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            category = _mapper.Map<Category>(request);
            await _categoryRepository.UpdateAsync(category);
            UpdatedCategoryResponse updatedCategoryResponse = _mapper.Map<UpdatedCategoryResponse>(category);
            return updatedCategoryResponse;
        }
    }
}
