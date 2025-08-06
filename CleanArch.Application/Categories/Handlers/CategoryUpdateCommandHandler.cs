using CleanArch.Application.Categories.Commands;
using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class CategoryUpdateCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<Category> Handle(CategoryUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                category.Update(request.Name);

                return await _categoryRepository.UpdateAsync(category);

            }
        }
    }
}
