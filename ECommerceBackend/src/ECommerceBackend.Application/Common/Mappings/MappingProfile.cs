using AutoMapper;
using ECommerceBackend.Application.Features.Products.Commands.CreateProduct;
using ECommerceBackend.Application.Features.Products.Dtos;
using ECommerceBackend.Domain.Entities;

namespace ECommerceBackend.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductCommand, Product>()
            .ConstructUsing(cmd => new Product(cmd.Name, cmd.Description, cmd.Price, cmd.StockQuantity));
    }
} 