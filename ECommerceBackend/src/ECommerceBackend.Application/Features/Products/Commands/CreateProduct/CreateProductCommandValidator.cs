using FluentValidation;

namespace ECommerceBackend.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(p => p.Description)
            .MaximumLength(500);

        RuleFor(p => p.Price)
            .GreaterThan(0);

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0);
    }
} 