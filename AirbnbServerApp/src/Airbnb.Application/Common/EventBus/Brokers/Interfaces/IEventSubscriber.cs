namespace Airbnb.Application.Common.EventBus.Brokers.Interfaces;
///<summary>
/// Defines the interface for an event subscriber.
///</summary>
public interface IEventSubscriber
{
    ///<summary>
    /// Asynchronously starts the event subscriber.
    ///</summary>
    ///<param name="token">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous start operation.</returns>
    ValueTask StartAsync(CancellationToken token);

    ///<summary>
    /// Asynchronously stops the event subscriber.
    ///</summary>
    ///<param name="token">A cancellation token to signal when to stop the operation.</param>
    ///<returns>A task representing the asynchronous stop operation.</returns>
    ValueTask StopAsync(CancellationToken token);
}
