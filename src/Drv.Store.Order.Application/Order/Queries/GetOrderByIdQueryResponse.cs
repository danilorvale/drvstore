namespace Drv.Store.Order.Application.Order.Queries;

public sealed record GetOrderByIdQueryResponse(Guid Id, string CustomerName, string CustomerEmail, decimal Total, DateTime CreatedAt, IList<GetOrderItemResponse> OrderItems);

public sealed record GetOrderItemResponse(Guid Id, Guid ProductId, string ProductName, string ProductDescription, int Quantity, decimal Price, decimal TotalPrice);
