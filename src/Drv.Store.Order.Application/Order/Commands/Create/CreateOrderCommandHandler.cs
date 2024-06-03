using Drv.Store.Order.Domain.Abstractions;
using Drv.Store.Shared.Messaging;
using Drv.Store.Shared.Validation;
using MassTransit;

namespace Drv.Store.Order.Application.Order.Commands.Create;

internal sealed class CreateOrderCommandHandler(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<CreateOrderCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEvent = new CreateOrderEvent(Guid.NewGuid(), request.CustomerName, request.CustomerEmail, request.Items.Select(i => new CreateOrderItemEvent(i.ProductId, i.Quantity)).ToList());

        await publishEndpoint.Publish(orderEvent, cancellationToken);

        return orderEvent.Id;
    }
}