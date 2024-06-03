using Drv.Store.Order.Domain.Primitives;

namespace Drv.Store.Order.Domain.Entities;

public sealed class Customer(Guid id, string name,string email) : Entity(id)
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public IList<Order> Orders { get; private set; } = new List<Order>();
}