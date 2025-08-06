using CleanArch.Application.Categories.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class CategoryCreateCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryCreateCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Category> Handle(CategoryCreateCommand request,
        CancellationToken cancellationToken)
    {

        var newCategorie = new Category(request.Name);

        if (request == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _categoryRepository.CreateAsync(newCategorie);
        }
    }
}
