using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Category> CreateAsync(Category entity)
    {
        var retorno = await _categoryRepository.CreateAsync(entity);

        return retorno;
    }
    public async Task<IEnumerable<Category>> GetAllAsync() => await _categoryRepository.GetAllAsync();
    public async Task<Category?> GetByIdAsync(int? id) => await _categoryRepository.GetByIdAsync(id);

    public async Task<Category> UpdateAsync(int id)
    {
        var entityExists = await _categoryRepository.GetByIdAsync(id) 
            ?? throw new Exception("Entidade não encontrada na base de dados.");

        var retorno = await _categoryRepository.UpdateAsync(entityExists);

        return retorno;
    }

    public async Task<Category> DeleteAsync(int id)
    {
        var entityExists = await _categoryRepository.GetByIdAsync(id)
            ?? throw new Exception("Entidade não encontrada na base de dados.");

        var retorno = await _categoryRepository.DeleteAsync(entityExists);

        return retorno;
    }
}
