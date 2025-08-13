using CleanArch.Application.DTOs;

namespace CleanArch.WebUI.Domain.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO?> GetByIdAsync(int id);

    Task CreateAsync(ProductDTO entity);
    Task UpdateAsync(ProductDTO entity);
    Task DeleteAsync(int id);
}