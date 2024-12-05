using MassTransit;
using Order.Api.Entities;
using Order.Api.Infrastructure.Persistence;


namespace Order.Api.Bus
{
    public class OrderConsumer : IConsumer<BasketCheckout>
    {
        private readonly OrderInfoContext _dbcontext;
        public OrderConsumer(OrderInfoContext context)
        {
            _dbcontext = context;
        }

        public async Task Consume(ConsumeContext<BasketCheckout> mqcontext)
        {
            var msg = mqcontext.Message;
            var order = await HeavyProccessing(msg);
            await _dbcontext.Orders.AddAsync(order);
        }

        public async Task<OrderInfo> HeavyProccessing(BasketCheckout checkout){
            await Task.Delay(120000);
            var order = new OrderInfo()
            {
                OrderId = Guid.NewGuid(),
                Customer = checkout.Customer,
                Items = checkout.Items
            };
            return order;
        }
    }
}