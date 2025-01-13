using ECommerceBackend.Application.Features.Products.Commands.CreateProduct;
using ECommerceBackend.Application.Features.Products.Dtos;
using ECommerceBackend.Application.Features.Queries;
using ECommerceBackend.Application.Interfaces;
using ECommerceBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.API.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductRepository _productRepository;

    public ProductsController(IMediator mediator, IProductRepository productRepository)
    {
        _mediator = mediator;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
    {
        var query = new GetProductQuery(id);
        var productDto = await _mediator.Send(query);
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateProduct(CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProduct), new { id = productId }, productId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        await _productRepository.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        await _productRepository.DeleteAsync(product);
        return NoContent();
    }
} 