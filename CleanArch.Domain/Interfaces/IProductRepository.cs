using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetProductCategoryAsync(int? id);
}
