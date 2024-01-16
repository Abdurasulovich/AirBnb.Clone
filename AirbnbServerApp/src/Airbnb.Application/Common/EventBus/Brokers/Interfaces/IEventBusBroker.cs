using Airbnb.Domain.Common.Events;

namespace Airbnb.Application.Common.EventBus.Brokers.Interfaces;
///<summary>
/// Defines the interface for an event bus broker responsible for publishing events.
///</summary>
public interface IEventBusBroker
{
    ///<summary>
    /// Asynchronously publishes an event to the specified exchange with the given routing key.
    ///</summary>
    ///<typeparam name="TEvent">The type of event to be published.</typeparam>
    ///<param name="event">The event to be published.</param>
    ///<param name="exchange">The exchange to which the event is published.</param>
    ///<param name="routingKey">The routing key used for the event.</param>
    ///<param name="cancellationToken">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous publish operation.</returns>
    ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey,
        CancellationToken cancellationToken) where TEvent : Event;
}
