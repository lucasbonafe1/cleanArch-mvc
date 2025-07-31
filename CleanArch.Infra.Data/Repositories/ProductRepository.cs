using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Product> CreateAsync(Product entity)
    {
        await _appDbContext.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => await _appDbContext.Products.ToListAsync();
    
    public async Task<Product?> GetByIdAsync(int? id) => await _appDbContext.Products.FindAsync(id);

    public async Task<Product?> GetProductCategoryAsync(int? id) => await _appDbContext.Products.Include(i => i.Category).FirstOrDefaultAsync(f => f.Id == id);

    public async Task<Product> UpdateAsync(Product entity)
    {
        _appDbContext.Products.Update(entity);
        await _appDbContext.SaveChangesAsync();

        return entity;
    }
    public async Task<Product> DeleteAsync(Product entity)
    {
        _appDbContext.Products.Remove(entity);
        await _appDbContext.SaveChangesAsync();

        return entity;
    }
}