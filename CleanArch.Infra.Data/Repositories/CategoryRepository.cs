using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public async Task<Category> CreateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> DeleteAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetByIdAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> UpdateAsync(Category entity)
    {
        throw new NotImplementedException();
    }
}
