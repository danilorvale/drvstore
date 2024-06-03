using Drv.Store.Shared.Messaging;

namespace Drv.Store.Order.Application.Order.Queries;

public sealed record GetOrderByIdQuery(Guid Id) : IQuery<GetOrderByIdQueryResponse>;