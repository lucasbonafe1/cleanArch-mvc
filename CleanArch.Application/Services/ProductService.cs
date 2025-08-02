using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class ProductService(IProductRepository produtoRepository) : IProductService
{
    private readonly IProductRepository _produtoRepository = produtoRepository;

    public async Task<Product> CreateAsync(Product entity)
    {
        var retorno = await _produtoRepository.CreateAsync(entity);

        return retorno;
    }
    public async Task<IEnumerable<Product>> GetAllAsync() => await _produtoRepository.GetAllAsync();
    public async Task<Product?> GetByIdAsync(int? id) => await _produtoRepository.GetByIdAsync(id);
    public async Task<Product?> GetProductCategoryAsync(int? id) => await _produtoRepository.GetByIdAsync(id);

    public async Task<Product> UpdateAsync(int id)
    {
        var entityExists = await _produtoRepository.GetByIdAsync(id)
            ?? throw new Exception("Entidade não encontrada na base de dados.");

        var retorno = await _produtoRepository.UpdateAsync(entityExists);

        return retorno;
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var entityExists = await _produtoRepository.GetByIdAsync(id)
            ?? throw new Exception("Entidade não encontrada na base de dados.");

        var retorno = await _produtoRepository.DeleteAsync(entityExists);

        return retorno;
    }
}
