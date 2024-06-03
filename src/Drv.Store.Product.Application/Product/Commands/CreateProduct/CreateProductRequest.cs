namespace Drv.Store.Product.Application.Product.Commands.CreateProduct;

public sealed record CreateProductRequest(string Name, string Description, decimal Price);