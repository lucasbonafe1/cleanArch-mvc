using CleanArch.Application.Categories.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class CategoryRemoveCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryRemoveCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Category> Handle(CategoryRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            var result = await _categoryRepository.DeleteAsync(category);
            return result;
        }
    }
}
