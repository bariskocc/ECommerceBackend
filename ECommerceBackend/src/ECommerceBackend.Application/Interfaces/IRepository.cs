using ECommerceBackend.Domain.Common;

namespace ECommerceBackend.Application.Interfaces;

public interface IRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
} 