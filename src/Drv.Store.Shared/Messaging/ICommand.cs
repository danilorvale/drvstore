using Drv.Store.Shared.Validation;
using MediatR;

namespace Drv.Store.Shared.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, ICommandBase
{
}

public interface ICommandBase
{
}