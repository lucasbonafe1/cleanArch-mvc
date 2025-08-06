using CleanArch.Application.Categories.Queries;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllAsync();
    }
}
