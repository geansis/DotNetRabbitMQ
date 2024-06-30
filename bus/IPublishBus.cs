using MassTransit;
using TodoApi.reports;

namespace TodoApi.bus;

internal interface IPublishBus{
    Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class;
}

internal class PublishBus : IPublishBus{
    private readonly IPublishEndpoint _busEndpoint;

    public PublishBus(IPublishEndpoint publishEndpoint){
        _busEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class{
        await _busEndpoint.Publish(message, ct);
    }
}