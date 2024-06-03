namespace Drv.Store.Order.Application.Order.Commands.Create;

public sealed record CreateOrderEvent(Guid Id, string CustomerName, string CustomerEmail, IList<CreateOrderItemEvent> Items);

public sealed record CreateOrderItemEvent(Guid ProductId, int Quantity);