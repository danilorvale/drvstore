using Drv.Store.Shared.Infrastructure.Authentication;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;

namespace Drv.Store.Product.Application.User.Commands.Authenticate;

internal sealed class AuthenticateCommandHandler(IJwtProvider jwtProvider) : ICommandHandler<AuthenticateCommand, string>
{
    public Task<Result<string>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        if (request.User != "admin" && request.Password != "admin")
            return Task.FromResult(Result.Failure<string>(new Error("Unauthorized", "Usuário ou senha inválidos")));

        return Task.FromResult<Result<string>>(jwtProvider.Generate(request.User));
    }
}

