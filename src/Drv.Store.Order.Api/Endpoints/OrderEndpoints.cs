using Drv.Store.Order.Api.Extensions;
using Drv.Store.Order.Application.Order.Commands.Create;
using Drv.Store.Order.Application.Order.Queries;
using Mapster;
using MediatR;

namespace Drv.Store.Order.Api.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("api/store").RequireAuthorization();

        group.MapPost("/orders", Create)
            .Produces<Guid>()
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/orders/{id}", Get)
            .Produces<GetOrderByIdQueryResponse>()
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent);
    }

    private static async Task<IResult> Create(CreateOrderRequest request, CancellationToken cancellationToken,
        ISender sender)
    {
        CreateOrderCommand command = request.Adapt<CreateOrderCommand>();

        var result = await sender.Send(command, cancellationToken)!;

        if (result.IsFailure)
            return result.HandleFailure();

        return Results.Ok(result.Value);
    }


    private static async Task<IResult> Get(Guid id, CancellationToken cancellationToken, ISender sender)
    {
        GetOrderByIdQuery query = new GetOrderByIdQuery(id);

        var result = await sender.Send(query, cancellationToken)!;

        if(result.IsFailure)
            return result.HandleFailure();

        return Results.Ok(result.Value);
    }
}