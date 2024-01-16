using RabbitMQ.Client;

namespace Airbnb.Application.Common.EventBus.Brokers.Interfaces;

///<summary>
/// Defines the interface for a RabbitMQ connection provider, responsible for creating channels.
///</summary>
public interface IRabbitMqConnectionProvider
{
    ///<summary>
    /// Asynchronously creates a RabbitMQ channel.
    ///</summary>
    ///<returns>A task representing the asynchronous channel creation operation.</returns>
    ValueTask<IChannel> CreateChannelAsync();
}
