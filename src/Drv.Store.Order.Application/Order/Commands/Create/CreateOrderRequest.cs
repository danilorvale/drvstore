namespace Drv.Store.Order.Application.Order.Commands.Create;

public sealed record CreateOrderRequest(string CustomerName, string CustomerEmail, IList<CreateOrderItemRequest> Items);

public sealed record CreateOrderItemRequest(Guid ProductId, int Quantity);