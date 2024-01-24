using Airbnb.Domain.Common.Exceptions;

namespace Airbnb.Domain.Extensions;

///<summary>
/// Extension methods for handling asynchronous functions and capturing their results or exceptions.
///</summary>
public static class ExceptionExtensions
{
    ///<summary>
    /// Executes an asynchronous function returning a non-nullable struct and captures its result or exception.
    ///</summary>
    ///<typeparam name="T">The type of the non-nullable struct returned by the function.</typeparam>
    ///<param name="func">The asynchronous function to be executed.</param>
    ///<returns>A ValueTask of FuncResult containing the result or exception.</returns>
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<Task<T>> func) where T : struct
    {
        FuncResult<T> result;
        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }

    ///<summary>
    /// Executes an asynchronous function returning a non-nullable struct (ValueTask) and captures its result or exception.
    ///</summary>
    ///<typeparam name="T">The type of the non-nullable struct returned by the function.</typeparam>
    ///<param name="func">The asynchronous function to be executed.</param>
    ///<returns>A ValueTask of FuncResult containing the result or exception.</returns>
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<ValueTask<T>> func) where T : struct
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }

    ///<summary>
    /// Executes an asynchronous function returning a boolean result and captures its result or exception.
    ///</summary>
    ///<param name="func">The asynchronous function to be executed.</param>
    ///<returns>A ValueTask of FuncResult containing the result or exception.</returns>
    public static async ValueTask<FuncResult<bool>> GetValueAsync(this Func<ValueTask> func)
    {
        FuncResult<bool> result;
        try
        {
            await func();
            result = new FuncResult<bool>(true);
        }
        catch (Exception e)
        {
            result = new FuncResult<bool>(e);
        }

        return result;
    }
}
