using Drv.Store.Shared.Validation;
using MediatR;

namespace Drv.Store.Shared.Messaging;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}