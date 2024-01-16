using Newtonsoft.Json;

namespace Airbnb.Application.Common.Serializer;

///<summary>
/// Defines the interface for a provider of JSON serialization settings.
///</summary>
public interface IJsonSerializationSettingsProvider
{
    ///<summary>
    /// Gets the JSON serialization settings.
    ///</summary>
    ///<param name="clone">Flag indicating whether to clone the settings to prevent modification (default is false).</param>
    ///<returns>The JSON serialization settings.</returns>
    JsonSerializerSettings Get(bool clone = false);
}
