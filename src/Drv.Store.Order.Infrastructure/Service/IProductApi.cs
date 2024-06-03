using Drv.Store.Order.Domain.Constracts;
using Refit;

namespace Drv.Store.Order.Infrastructure.Service;

public interface IProductApi
{
    [Post("/user/authenticate")]
    Task<string> AuthenticateAsync([HeaderCollection] IDictionary<string, string> headers, UserAuthenticateRequest request, CancellationToken cancellationToken);

    [Get("/products/{id}")]
    Task<GeProductResponse> GetProductById([HeaderCollection] IDictionary<string,string> headers, Guid id, CancellationToken cancellationToken);
}