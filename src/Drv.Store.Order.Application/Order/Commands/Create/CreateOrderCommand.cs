using Drv.Store.Shared.Messaging;

namespace Drv.Store.Order.Application.Order.Commands.Create;

public sealed record CreateOrderCommand(string CustomerName, string CustomerEmail, IList<CreateOrderItem> Items) : ICommand<Guid>;

public sealed record CreateOrderItem(Guid ProductId, int Quantity);