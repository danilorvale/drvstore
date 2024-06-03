using Drv.Store.Shared.Messaging;

namespace Drv.Store.Order.Application.User.Commands.Authenticate;

public sealed record AuthenticateCommand(string User, string Password) : ICommand<string>;