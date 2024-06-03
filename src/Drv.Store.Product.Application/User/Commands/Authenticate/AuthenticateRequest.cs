namespace Drv.Store.Product.Application.User.Commands.Authenticate;

public sealed record AuthenticateRequest(string User, string Password);