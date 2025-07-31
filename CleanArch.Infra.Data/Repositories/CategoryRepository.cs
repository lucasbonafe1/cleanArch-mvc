using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories;

public class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Category> CreateAsync(Category entity)
    {
        await _appDbContext.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<Category>> GetAllAsync() => await _appDbContext.Categories.ToListAsync();

    public async Task<Category?> GetByIdAsync(int? id) => await _appDbContext.Categories.FindAsync(id);

    public async Task<Category> UpdateAsync(Category entity)
    {
        _appDbContext.Categories.Update(entity);
        await _appDbContext.SaveChangesAsync();

        return entity;
    }
    public async Task<Category> DeleteAsync(Category entity)
    {
        _appDbContext.Categories.Remove(entity);
        await _appDbContext.SaveChangesAsync();

        return entity;
    }
}
