using ECommerceBackend.Domain.Entities;
using Xunit;

namespace ECommerceBackend.UnitTests.Domain;

public class ProductTests
{
    [Fact]
    public void CreateProduct_WithValidParameters_ShouldCreateProduct()
    {
        // Arrange
        string name = "Test Product";
        string description = "Test Description";
        decimal price = 99.99m;
        int stockQuantity = 10;

        // Act
        var product = new Product(name, description, price, stockQuantity);

        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(price, product.Price);
        Assert.Equal(stockQuantity, product.StockQuantity);
    }

    [Fact]
    public void UpdateStock_ShouldUpdateStockQuantityAndModifiedDate()
    {
        // Arrange
        var product = new Product("Test Product", "Description", 99.99m, 10);
        var newQuantity = 20;
        var beforeUpdate = DateTime.UtcNow;

        // Act
        product.UpdateStock(newQuantity);

        // Assert
        Assert.Equal(newQuantity, product.StockQuantity);
        Assert.True(product.ModifiedDate.HasValue);
        Assert.True(product.ModifiedDate > beforeUpdate);
    }
} 