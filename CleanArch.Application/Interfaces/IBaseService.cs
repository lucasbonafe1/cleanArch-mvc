namespace CleanArch.Application.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int? id);

    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(int id);
    Task<T> DeleteAsync(int id);
}
