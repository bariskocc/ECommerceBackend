using MediatR;
using ECommerceBackend.Application.Interfaces;
using ECommerceBackend.Domain.Entities;
using ECommerceBackend.Application.Features.Products.Dtos;
using ECommerceBackend.Application.Common.Exceptions;

namespace ECommerceBackend.Application.Features.Queries;

public class GetProductQuery : IRequest<ProductDto>
{
    public Guid Id { get; }

    public GetProductQuery(Guid id)
    {
        Id = id;
    }
}
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        // ProductDto'ya dönüştürme işlemi yapılabilir
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            CreatedDate = product.CreatedDate,
            ModifiedDate = product.ModifiedDate
        };
    }
}

