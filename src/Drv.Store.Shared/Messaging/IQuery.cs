using Drv.Store.Shared.Validation;
using MediatR;

namespace Drv.Store.Shared.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}