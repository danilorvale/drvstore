using Drv.Store.Order.Domain.Entities;

namespace Drv.Store.Order.Domain.Abstractions;

public interface IOrderRepository
{
    Task CreateAsync(Entities.Order order, CancellationToken cancellationToken = default);
    void Update(Entities.Order order);
    void Delete(Entities.Order order);
    Task<Entities.Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}