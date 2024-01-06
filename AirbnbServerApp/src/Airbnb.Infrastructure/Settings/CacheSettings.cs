using System.Runtime.InteropServices.Marshalling;

namespace Airbnb.Infrastructure.Settings;

public class CacheSettings
{
    public uint AbsoluteExpirationInSeconds { get; set; }

    public uint SlidingExpirationInSeconds { get; set; }
}