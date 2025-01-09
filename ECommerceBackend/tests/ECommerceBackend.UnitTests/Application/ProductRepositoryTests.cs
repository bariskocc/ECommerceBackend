using ECommerceBackend.Application.Interfaces;
using ECommerceBackend.Domain.Entities;
using ECommerceBackend.Infrastructure.Persistence;
using ECommerceBackend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ECommerceBackend.UnitTests.Application;

public class ProductRepositoryTests
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public ProductRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
    }

    private ApplicationDbContext CreateContext()
    {
        var context = new ApplicationDbContext(_dbContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        using var context = CreateContext();
        var repository = new ProductRepository(context);
        var product = new Product("Test Product", "Description", 99.99m, 10);
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(product.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
    }

    [Fact]
    public async Task GetProductsByNameAsync_ShouldReturnMatchingProducts()
    {
        // Arrange
        using var context = CreateContext();
        var repository = new ProductRepository(context);
        
        var products = new List<Product>
        {
            new Product("Test Product 1", "Description", 99.99m, 10),
            new Product("Test Product 2", "Description", 149.99m, 20),
            new Product("Different Name", "Description", 199.99m, 30)
        };

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetProductsByNameAsync("Test Product");

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, p => Assert.Contains("Test Product", p.Name));
    }
} 