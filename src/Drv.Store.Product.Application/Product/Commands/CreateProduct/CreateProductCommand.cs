using Drv.Store.Shared.Messaging;

namespace Drv.Store.Product.Application.Product.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string Description, decimal Price) : ICommand<Guid>;