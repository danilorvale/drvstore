using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Drv.Store.Product.Infrastructure.Database;

public sealed class ProductRepository(ApplicationDbContext applicationDbContext) : Domain.Abstractions.IProductRepository
{

    public async Task CreateAsync(Domain.Entities.Product product, CancellationToken cancellationToken = default)
    {
        await applicationDbContext.Products.AddAsync(product, cancellationToken);
    }

    public void Update(Domain.Entities.Product product)
    {
        applicationDbContext.Products.Update(product);
    }

    public void Delete(Domain.Entities.Product product)
    {
        EntityEntry<Domain.Entities.Product> productEntity = applicationDbContext.Products.Attach(product);
        productEntity.State = EntityState.Deleted;
    }

    public async Task<Domain.Entities.Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Product? product = await applicationDbContext.Products
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return product;
    }
}