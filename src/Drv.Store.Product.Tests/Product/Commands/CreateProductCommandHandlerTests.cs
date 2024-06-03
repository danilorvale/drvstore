using Drv.Store.Product.Application.Product.Commands.CreateProduct;
using Drv.Store.Product.Domain.Abstractions;
using Drv.Store.Shared.Validation;
using FluentValidation.TestHelper;
using Moq;

namespace Drv.Store.Product.Tests.Product.Commands;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _mockProductRepository = new();

    [Fact]
    public void Handle_Should_ThrowValidationException_WhenNameIsInvalid()
    {
        // Arrange
        var command = new CreateProductCommand(String.Empty, "teste", 10);

        var validator = new CreateProductCommandValidator();

        //Act
        TestValidationResult<CreateProductCommand>? result = validator.TestValidate(command);

        //Assert
        if (result != null) result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void Handle_Should_ThrowValidationException_WhenDescriptionIsInvalid()
    {
        // Arrange
        var command = new CreateProductCommand("teste", String.Empty, 10);

        var validator = new CreateProductCommandValidator();

        //Act
        TestValidationResult<CreateProductCommand>? result = validator.TestValidate(command);

        //Assert
        if (result != null) result.ShouldHaveValidationErrorFor(c => c.Description);
    }

    [Fact]
    public void Handle_Should_ThrowValidationException_WhenPriceIsInvalid()
    {
        // Arrange
        var command = new CreateProductCommand("teste", "teste", 0);

        var validator = new CreateProductCommandValidator();

        //Act
        TestValidationResult<CreateProductCommand>? result = validator.TestValidate(command);

        //Assert
        if (result != null) result.ShouldHaveValidationErrorFor(c => c.Price);
    }

    [Fact]
    public void Handle_Should_ReturnSuccessResult_WhenProductIsCreated()
    {
        // Arrange
        var command = new CreateProductCommand("teste", "teste", 10);

        _mockProductRepository.Setup(
                x => x.CreateAsync(
                    It.IsAny<Domain.Entities.Product>(),
                    It.IsAny<CancellationToken>()))
            ;

        var handler = new CreateProductCommandHandler(
            _mockProductRepository.Object);

        // Act
        Result<Guid> result = handler.Handle(command, default).Result;

        // Assert
        _mockProductRepository.Verify(
            x => x.CreateAsync(It.Is<Domain.Entities.Product>(p => p.Id == result.Value), It.IsAny<CancellationToken>()),
            Times.Once);
        //result.IsSuccess.Should().BeTrue();
    }
}