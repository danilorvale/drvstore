using Drv.Store.Order.Domain.Primitives;

namespace Drv.Store.Order.Domain.Entities;

public sealed class Order: Entity
{
    internal Order(Guid id)
    :base(id)
    {}

    public Order(Guid id, Guid customerId, string customerName, string customerMail)
    :base(id)
    {
        CustomerId = customerId;
        Customer = new Customer(customerId, customerName, customerMail);
        CreatedAt = DateTime.UtcNow;
    }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IList<OrderItem> Items { get; private set; } = new List<OrderItem>();

    public void AddItem(Guid productId, int quantity)
    {
        Items.Add(new OrderItem(Guid.NewGuid(), productId, quantity, Id));
    }
}