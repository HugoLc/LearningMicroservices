using MassTransit;

namespace Basket.Api.Extensions; 
public static class ServiceExtension
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((ctx, cfg)=>
                {
                    //TODO: salvar no env
                    cfg.Host(new Uri("amqp://rabbitmq:5672"), host=>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
        });
    }
}
