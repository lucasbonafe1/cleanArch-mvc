using CleanArch.Application.DTOs;

namespace CleanArch.WebUI.Domain.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
    Task<CategoryDTO?> GetByIdAsync(int id);

    Task CreateAsync(CategoryDTO entity);
    Task UpdateAsync(CategoryDTO entity);
    Task DeleteAsync(int id);
}