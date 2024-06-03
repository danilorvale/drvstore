namespace Drv.Store.Product.Application.Product.Queries.GetProduct;

public sealed record GetProductResponse(Guid Id, string Name, string Description, Decimal Price);