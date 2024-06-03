using FluentValidation;

namespace Drv.Store.Order.Application.Order.Commands.Create;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required");

        RuleFor(x => x.CustomerEmail)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Customer email is required");

        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("Items are required");

        RuleForEach(x => x.Items).SetValidator(new CreateOrderItemValidator());
    }
}

public sealed class CreateOrderItemValidator : AbstractValidator<CreateOrderItem>
{
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product id is required");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
    }
}