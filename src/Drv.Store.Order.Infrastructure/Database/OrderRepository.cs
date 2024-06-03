using Drv.Store.Order.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Drv.Store.Order.Infrastructure.Database;

public sealed class OrderRepository(ApplicationDbContext applicationDbContext) : IOrderRepository
{
    public async Task CreateAsync(Domain.Entities.Order order, CancellationToken cancellationToken = default)
    {
        await applicationDbContext.Orders.AddAsync(order, cancellationToken);
    }

    public void Update(Domain.Entities.Order order)
    {
        applicationDbContext.Orders.Update(order);
    }

    public void Delete(Domain.Entities.Order order)
    {
        EntityEntry<Domain.Entities.Order> orderEntity = applicationDbContext.Orders.Attach(order);
        orderEntity.State = EntityState.Deleted;
    }

    public async Task<Domain.Entities.Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Order? order = await applicationDbContext.Orders
            .AsNoTracking()
            .Include(o => o.Items)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return order;
    }
}