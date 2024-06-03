using Drv.Store.Shared.Messaging;

namespace Drv.Store.Product.Application.Product.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : ICommand<Guid>;