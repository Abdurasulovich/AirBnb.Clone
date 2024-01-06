using Newtonsoft.Json;

namespace Airbnb.Application.Common.Serializer;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Get(bool clone = false);
}