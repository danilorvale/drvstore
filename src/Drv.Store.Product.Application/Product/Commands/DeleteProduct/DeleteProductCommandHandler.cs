using Drv.Store.Product.Domain.Abstractions;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;

namespace Drv.Store.Product.Application.Product.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(command.Id, cancellationToken);

        if (product is null)
            return Result.Failure<Guid>(new Error("999", "Produto não encontrado"));

        productRepository.Delete(product);

        return product.Id;
    }
}