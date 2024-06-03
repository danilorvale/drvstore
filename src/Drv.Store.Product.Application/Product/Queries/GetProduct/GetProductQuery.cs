using Drv.Store.Shared.Messaging;

namespace Drv.Store.Product.Application.Product.Queries.GetProduct;

public sealed record GetProductQuery(Guid Id): IQuery<GetProductResponse>;