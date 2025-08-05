using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Interfaces;

public interface IProductService : IBaseService<ProductDTO>
{
    Task<ProductDTO?> GetProductCategoryAsync(int? id);
}
