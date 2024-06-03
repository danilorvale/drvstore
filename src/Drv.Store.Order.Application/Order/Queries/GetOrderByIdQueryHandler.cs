using Drv.Store.Order.Application.Abstractions;
using Drv.Store.Order.Domain.Abstractions;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;

namespace Drv.Store.Order.Application.Order.Queries;

internal class GetOrderByIdQueryHandler(IOrderRepository orderRepository, IProductService productService): IQueryHandler<GetOrderByIdQuery, GetOrderByIdQueryResponse>
{
    public async Task<Result<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
            return  Result.Failure<GetOrderByIdQueryResponse>(new Error("Order.NotFound", "Pedido não encontrado."));

        var orderItemResponse = await Task.WhenAll(order.Items.Select(async x =>
        {
            var product = await productService.GetByIdAsync(x.ProductId, cancellationToken);
            return new GetOrderItemResponse(x.Id, product.Id, product.Name,product.Description, x.Quantity, product.Price, product.Price * x.Quantity);
        }));

        var orderResponse = new GetOrderByIdQueryResponse(order.Id, order.Customer.Name
            ,order.Customer.Email, orderItemResponse.ToList().Sum(i => i.TotalPrice)
            ,order.CreatedAt, orderItemResponse.ToList());

        return orderResponse;
    }
}