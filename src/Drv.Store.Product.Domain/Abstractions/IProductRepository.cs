namespace Drv.Store.Product.Domain.Abstractions;

public interface IProductRepository
{
    Task CreateAsync(Entities.Product product, CancellationToken cancellationToken = default);
    void Update(Entities.Product product);
    void Delete(Entities.Product product);
    Task<Entities.Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}