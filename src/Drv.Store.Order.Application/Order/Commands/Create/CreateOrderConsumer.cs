using Drv.Store.Order.Domain.Abstractions;
using Drv.Store.Order.Domain.Entities;
using Drv.Store.Shared.Infrastructure.Data;
using MassTransit;

namespace Drv.Store.Order.Application.Order.Commands.Create;

public sealed class CreateOrderConsumer(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IConsumer<CreateOrderEvent>
{
    public async Task Consume(ConsumeContext<CreateOrderEvent> context)
    {
        var order = new Domain.Entities.Order(context.Message.Id, Guid.NewGuid(), context.Message.CustomerName, context.Message.CustomerEmail);

        foreach (var item in context.Message.Items)
            order.AddItem(item.ProductId, item.Quantity);

        await orderRepository.CreateAsync(order);

        await unitOfWork.SaveChangesAsync();
    }
}