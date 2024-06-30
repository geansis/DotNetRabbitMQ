

using MassTransit;
using TodoApi.bus;

internal static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services){

        services.AddTransient<IPublishBus, PublishBus>();

        services.AddMassTransit(busConfigurator => {

            busConfigurator.AddConsumer<ReportRequestedEventConsumer>();

            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri("amqp://localhost:5672"), host =>{
                    host.Username("guest");
                    host.Password("guest");
                });

                cfg.ConfigureEndpoints(context);

            });

       });
    }
}