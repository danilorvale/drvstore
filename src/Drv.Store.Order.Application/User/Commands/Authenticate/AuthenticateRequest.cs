namespace Drv.Store.Order.Application.User.Commands;

public sealed record AuthenticateRequest(string User, string Password);