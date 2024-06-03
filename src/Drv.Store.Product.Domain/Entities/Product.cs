using Drv.Store.Product.Domain.Primitives;

namespace Drv.Store.Product.Domain.Entities;

public sealed class Product(Guid id, string name, string description, decimal price) : Entity(id)
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public decimal Price { get; private set; } = price;

    public void Update(string? name, string? description, decimal? price)
    {
        if (name is not null) Name = name;
        if (description is not null) Description = description;
        if (price is not null) Price = price.Value;
    }
}
