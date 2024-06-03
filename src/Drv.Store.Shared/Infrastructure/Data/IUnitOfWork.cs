namespace Drv.Store.Shared.Infrastructure.Data;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}