using Drv.Store.Product.Api.Extensions;
using Drv.Store.Product.Application.Product.Commands.CreateProduct;
using Drv.Store.Product.Application.Product.Commands.DeleteProduct;
using Drv.Store.Product.Application.Product.Commands.UpdateProduct;
using Drv.Store.Product.Application.Product.Queries.GetProduct;
using Mapster;
using MediatR;

namespace Drv.Store.Product.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("api/store").RequireAuthorization();

        group.MapPost("/products", Create)
            .Produces<Guid>()
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/products/{id}", Get)
            .Produces<GetProductResponse>()
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/products/{id}", Delete)
            .Produces<Guid>()
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent);

        group.MapPut("/products/{id}", Update)
            .Produces<Guid>()
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent);
    }

    private static async Task<IResult> Create(CreateProductRequest request, CancellationToken cancellationToken,
        ISender sender)
    {
        CreateProductCommand command = request.Adapt<CreateProductCommand>();

        var result = await sender.Send(command, cancellationToken)!;

        if (result.IsFailure)
            return result.HandleFailure();

        return Results.Ok(result.Value);
    }

    private static async Task<IResult> Delete(Guid id, CancellationToken cancellationToken,
        ISender sender)
    {
        DeleteProductCommand command = new DeleteProductCommand(id);

        var result = await sender.Send(command, cancellationToken)!;

        if (result.IsFailure)
            return result.HandleFailure();

        return Results.Ok(result.Value);
    }

    private static async Task<IResult> Update(Guid id, UpdateProductRequest request, CancellationToken cancellationToken,
        ISender sender)
    {
        if(id != request.Id)
            return Results.BadRequest("O id do produto não corresponde ao id da requisição.");

        UpdateProductCommand command = request.Adapt<UpdateProductCommand>();

        var result = await sender.Send(command, cancellationToken)!;

        if (result.IsFailure)
            return result.HandleFailure();

        return Results.Ok(result.Value);
    }

    private static async Task<IResult> Get(Guid id, CancellationToken cancellationToken, ISender sender)
    {
        GetProductQuery query = new GetProductQuery(id);

        var result = await sender.Send(query, cancellationToken)!;

        if(result.IsFailure)
            return result.HandleFailure();

        return Results.Ok(result.Value);
    }
}