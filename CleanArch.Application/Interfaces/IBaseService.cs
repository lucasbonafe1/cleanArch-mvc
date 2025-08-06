namespace CleanArch.Application.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);

    Task CreateAsync(T entity);
    Task<T> UpdateAsync(int id);
    Task DeleteAsync(int id);
}
