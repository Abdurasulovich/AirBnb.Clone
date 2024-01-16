namespace Airbnb.Domain.Common.Events;

///<summary>
/// Base class for representing events with common properties.
///</summary>
public abstract class Event
{
    ///<summary>
    /// Gets or sets the unique identifier for the event.
    ///</summary>
    public Guid Id { get; set; } = Guid.Empty;
    
    ///<summary>
    /// Gets or sets the creation time of the event.
    ///</summary>
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now;
    
    ///<summary>
    /// Gets or sets a flag indicating whether the event is redelivered.
    ///</summary>
    public bool Redelivered { get; set; }
}
