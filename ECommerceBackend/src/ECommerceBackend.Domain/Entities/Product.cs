using ECommerceBackend.Domain.Common;

namespace ECommerceBackend.Domain.Entities;

public class Product : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    
    private Product() { } // EF Core için

    public Product(string name, string description, decimal price, int stockQuantity)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void UpdateStock(int quantity)
    {
        StockQuantity = quantity;
        ModifiedDate = DateTime.UtcNow;
    }
} 