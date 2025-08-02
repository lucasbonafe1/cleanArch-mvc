using CleanArch.Domain.Entities;

namespace CleanArch.Application.Interfaces;

public interface IProductService : IBaseService<Product>
{
    Task<Product?> GetProductCategoryAsync(int? id);
}
