using Drv.Store.Order.Domain.Primitives;

namespace Drv.Store.Order.Domain.Entities;

public sealed class OrderItem(Guid id, Guid productId, int quantity, Guid orderId) : Entity(id)
{
    public Order Order { get; private set; } = default!;
    public Guid OrderId { get; private set; } = orderId;
    public Guid ProductId { get; private set; } = productId;
    public int Quantity { get; private set; } = quantity;
}