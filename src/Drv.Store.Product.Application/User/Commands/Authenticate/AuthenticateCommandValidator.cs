using FluentValidation;

namespace Drv.Store.Product.Application.User.Commands.Authenticate;

public sealed class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
{
    public AuthenticateCommandValidator()
    {
        RuleFor(x => x.User)
            .NotEmpty()
            .WithMessage("Usuario é obrigatório.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Senha é obrigatória.");
    }
}