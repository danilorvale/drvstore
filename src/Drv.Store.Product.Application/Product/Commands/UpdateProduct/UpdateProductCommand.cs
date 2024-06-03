using Drv.Store.Shared.Messaging;
using MediatR;

namespace Drv.Store.Product.Application.Product.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id, string? Name, string? Description, Decimal? Price) : ICommand<Guid>;