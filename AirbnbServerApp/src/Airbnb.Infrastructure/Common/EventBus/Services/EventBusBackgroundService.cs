using Airbnb.Application.Common.EventBus.Brokers.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Airbnb.Infrastructure.Common.EventBus.Services;

///<summary>
/// Background service responsible for starting and stopping event subscribers.
/// Initializes a new instance of the EventBusBackgroundService class with the specified event subscribers.
///</summary>
///<param name="eventSubscribers">The collection of event subscribers.</param>
public class EventBusBackgroundService(IEnumerable<IEventSubscriber> eventSubscribers) : BackgroundService
{
    ///<inheritdoc/>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.WhenAll(eventSubscribers.Select(eventSubscriber =>
            eventSubscriber.StartAsync(stoppingToken).AsTask()));
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.WhenAll(eventSubscribers.Select(eventSubscriber =>
            eventSubscriber.StopAsync(cancellationToken).AsTask()));
    }
}