namespace Drv.Store.Product.Application.Product.Commands.UpdateProduct;

public sealed record UpdateProductRequest(Guid Id, string? Name, string? Description, Decimal? Price);