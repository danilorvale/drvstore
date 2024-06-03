using Drv.Store.Product.Api.Extensions;
using Drv.Store.Product.Application.User.Commands.Authenticate;
using Mapster;
using MediatR;

namespace Drv.Store.Product.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("api/store/user");

        group.MapPost("/authenticate", Authenticate)
            .Produces<string>()
            .AllowAnonymous();
    }

    private static async Task<IResult> Authenticate(AuthenticateRequest request, CancellationToken cancellationToken,
        ISender sender)
    {
        AuthenticateCommand command = request.Adapt<AuthenticateCommand>();

        var result = await sender.Send(command, cancellationToken)!;

        if (result.IsFailure)
            return Results.Unauthorized();

        return Results.Ok(result.Value);
    }
}