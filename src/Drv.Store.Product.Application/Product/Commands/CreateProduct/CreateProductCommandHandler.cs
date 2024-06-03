using Drv.Store.Product.Domain.Abstractions;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;

namespace Drv.Store.Product.Application.Product.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product(Guid.NewGuid(), request.Name, request.Description, request.Price);

        await productRepository.CreateAsync(product, cancellationToken);

        return product.Id;
    }
}