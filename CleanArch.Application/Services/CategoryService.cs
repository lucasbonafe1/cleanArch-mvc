using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Services;

public class CategoryService : ICategoryService
{
    //colocar no padrão cqrs
    public Task CreateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetByIdAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(int id)
    {
        throw new NotImplementedException();
    }
}
