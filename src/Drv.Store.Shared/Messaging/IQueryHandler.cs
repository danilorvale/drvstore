using Drv.Store.Shared.Validation;
using MediatR;

namespace Drv.Store.Shared.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
