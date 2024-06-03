namespace Drv.Store.Order.Domain.Constracts;

public sealed record GeProductResponse(Guid Id,string Name, decimal Price, string Description);