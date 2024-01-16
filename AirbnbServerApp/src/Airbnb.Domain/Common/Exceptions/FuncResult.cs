namespace Airbnb.Domain.Common.Exceptions;

///<summary>
/// Represents the result of a function with either data or an exception.
///</summary>
public class FuncResult<T>
{
    ///<summary>
    /// Constructor for a successful result with data.
    ///</summary>
    ///<param name="data">The data result of the function.</param>
    public FuncResult(T data)
    {
        Data = data;
    }

    ///<summary>
    /// Constructor for a failed result with an exception.
    ///</summary>
    ///<param name="exception">The exception representing the failure.</param>
    public FuncResult(Exception exception)
    {
        Exception = exception;
    }

    ///<summary>
    /// Gets or sets the data result of the function.
    ///</summary>
    public T Data { get; init; }
    
    ///<summary>
    /// Gets or sets the exception representing the failure, if any.
    ///</summary>
    public Exception? Exception { get; set; }

    ///<summary>
    /// Gets a boolean indicating whether the result is a success (no exception).
    ///</summary>
    public bool IsSuccess => Exception is null;
}
