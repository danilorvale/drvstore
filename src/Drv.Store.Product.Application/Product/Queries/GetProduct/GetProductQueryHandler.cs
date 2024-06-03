using Drv.Store.Product.Domain.Abstractions;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;

namespace Drv.Store.Product.Application.Product.Queries.GetProduct;

internal sealed class GetProductQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductQuery, GetProductResponse>
{
    public async Task<Result<GetProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result.Failure<GetProductResponse>(new Error("NotFound", "Produto não encontrado"));

        return new GetProductResponse(product.Id, product.Name, product.Description, product.Price);
    }
}