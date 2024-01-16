using Airbnb.Application.Common.EventBus.Brokers.Interfaces;
using Airbnb.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Airbnb.Infrastructure.Common.EventBus.Brokers.Interfaces;

///<summary>
/// Implementation of the IRabbitMqConnectionProvider interface for managing RabbitMQ connections.
/// Initializes a new instance of the RabbitMqConnectionProvider class with the specified RabbitMQ connection settings.
///</summary>
///<param name="rabbitMqConnectionSettings">The RabbitMQ connection settings.</param>
public class RabbitMqConnectionProvider(IOptions<RabbitMqConnectionSettings> rabbitMqConnectionSettings) : IRabbitMqConnectionProvider
{
    private readonly ConnectionFactory _connectionFactory = new()
    {
        HostName = rabbitMqConnectionSettings.Value.HostName,
        Port = rabbitMqConnectionSettings.Value.Port
    };

    private IConnection? _connection;
    
    ///<inheritdoc/>
    public async ValueTask<IChannel> CreateChannelAsync()
    {
        _connection ??= await _connectionFactory.CreateConnectionAsync();

        return await _connection.CreateChannelAsync();
    }
}