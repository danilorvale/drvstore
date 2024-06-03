using Drv.Store.Order.Domain.Constracts;

namespace Drv.Store.Order.Application.Abstractions;

public interface IProductService
{
    Task<GeProductResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}