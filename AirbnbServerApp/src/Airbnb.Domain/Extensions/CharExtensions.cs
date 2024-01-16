using Microsoft.EntityFrameworkCore.Metadata;

namespace Airbnb.Domain.Extensions;

///<summary>
/// Extension methods for generating random characters of specific types.
///</summary>
public static class CharExtensions
{
    ///<summary>
    /// Gets a random digit character.
    ///</summary>
    ///<param name="random">Optional parameter for providing a custom Random instance.</param>
    ///<returns>A random digit character.</returns>
    public static char GetRandomDigit(Random? random = null)
    {
        return (char)(random ?? new Random()).Next('0', '9' + 1);
    }

    ///<summary>
    /// Gets a random uppercase character.
    ///</summary>
    ///<param name="random">Optional parameter for providing a custom Random instance.</param>
    ///<returns>A random uppercase character.</returns>
    public static char GetRandomUppercase(Random? random = null)
    {
        return (char)(random ?? new Random()).Next('A', 'Z' + 1);
    }

    ///<summary>
    /// Gets a random lowercase character.
    ///</summary>
    ///<param name="random">Optional parameter for providing a custom Random instance.</param>
    ///<returns>A random lowercase character.</returns>
    public static char GetRandomLowercase(Random? random = null)
    {
        return (char)(random ?? new Random()).Next('a', 'z' + 1);
    }

    ///<summary>
    /// Gets a random non-alphanumeric character from the set "!@#$%^&*()_-+<>?".
    ///</summary>
    ///<param name="random">Optional parameter for providing a custom Random instance.</param>
    ///<returns>A random non-alphanumeric character.</returns>
    public static char GetRandomNonAlphanumeric(Random? random = null)
    {
        return "!@#$%^&*()_-+<>?"[(random ?? new Random()).Next(16)];
    }

    ///<summary>
    /// Gets a random printable ASCII character (32 to 126).
    ///</summary>
    ///<param name="random">Optional parameter for providing a custom Random instance.</param>
    ///<returns>A random printable ASCII character.</returns>
    public static char GetRandomCharacter(Random? random = null)
    {
        return (char)(random ?? new Random()).Next(32, 126);
    }
}
