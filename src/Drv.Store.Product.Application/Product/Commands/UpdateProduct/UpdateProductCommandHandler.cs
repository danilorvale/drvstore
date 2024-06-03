using Drv.Store.Product.Domain.Abstractions;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;

namespace Drv.Store.Product.Application.Product.Commands.UpdateProduct;

internal sealed class UpdateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<UpdateProductCommand,Guid>
{

    public async Task<Result<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result.Failure<Guid>(new Error("999","Produto não encontrado"));

        product.Update(request.Name,request.Description,request.Price);

        productRepository.Update(product);

        return product.Id;
    }
}