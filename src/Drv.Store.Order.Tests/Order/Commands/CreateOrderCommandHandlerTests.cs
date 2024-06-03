using Drv.Store.Order.Application.Order.Commands.Create;
using FluentValidation.TestHelper;

namespace Drv.Store.Order.Tests.Order.Commands;

public class CreateOrderCommandHandlerTests
{
    [Fact]
    public void Handle_Should_ThrowValidationException_WhenCustomerNameIsInvalid()
    {
        // Arrange
        var command = new CreateOrderCommand(String.Empty, "danilorvale@gmail.com", new List<CreateOrderItem>());

        var validator = new CreateOrderCommandValidator();

        //Act
        TestValidationResult<CreateOrderCommand>? result = validator.TestValidate(command);

        //Assert
        if (result != null) result.ShouldHaveValidationErrorFor(c => c.CustomerName);
    }

    [Fact]
    public void Handle_Should_ThrowValidationException_WhenCustomerEmailIsInvalid()
    {
        // Arrange
        var command = new CreateOrderCommand("Danilo", "danilorvale", new List<CreateOrderItem>());

        var validator = new CreateOrderCommandValidator();

        //Act
        TestValidationResult<CreateOrderCommand>? result = validator.TestValidate(command);

        //Assert
        if (result != null) result.ShouldHaveValidationErrorFor(c => c.CustomerEmail);
    }
}