using ECommerceBackend.Domain.Entities;

namespace ECommerceBackend.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
} 