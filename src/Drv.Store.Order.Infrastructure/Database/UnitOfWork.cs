using Drv.Store.Shared.Infrastructure.Data;

namespace Drv.Store.Order.Infrastructure.Database;

public class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}