using System.Text;
using Airbnb.Application.Common.EventBus.Brokers.Interfaces;
using Airbnb.Application.Common.Serializer;
using Airbnb.Domain.Common.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;

namespace Airbnb.Infrastructure.Common.EventBus.Brokers;

///<summary>
/// Implementation of the IEventBusBroker interface for publishing events to RabbitMQ.
/// Initializes a new instance of the RabbitMqEventBusBroker class with the specified dependencies.
///</summary>
///<param name="rabbitMqConnectionProvider">The RabbitMQ connection provider.</param>
///<param name="jsonSerializationSettingsProvider">The JSON serialization settings provider.</param>

public class RabbitMqEventBusBroker(
    IRabbitMqConnectionProvider rabbitMqConnectionProvider, 
    IJsonSerializationSettingsProvider jsonSerializationSettingsProvider)
    : IEventBusBroker
{
    ///<inheritdoc/>
    public async ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken) where TEvent : Event
    {
        var channel = await rabbitMqConnectionProvider.CreateChannelAsync();

        var properties = new BasicProperties
        {
            Persistent = true
        };

        var serializeSettings = jsonSerializationSettingsProvider.Get(true);
        serializeSettings.ContractResolver = new DefaultContractResolver();
        serializeSettings.TypeNameHandling = TypeNameHandling.All;

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, serializeSettings));
        await channel.BasicPublishAsync(exchange, routingKey, properties, body);
    }
}