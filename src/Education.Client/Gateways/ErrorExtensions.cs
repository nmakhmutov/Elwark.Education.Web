using System.Diagnostics.CodeAnalysis;

namespace Education.Client.Gateways;

internal static class ErrorExtensions
{
    public static bool IsTestAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string id)
    {
        if (error.Type == "TestException:AlreadyCreated" && error.Extensions.TryGetValue("id", out var value))
        {
            id = value.ToString()!;
            return true;
        }

        id = null;
        return false;
    }

    public static bool IsTestAlreadyCompleted(this Error error, [MaybeNullWhen(false)] out string id)
    {
        if (error.Type == "TestException:AlreadyCompleted" && error.Extensions.TryGetValue("id", out var value))
        {
            id = value.ToString()!;
            return true;
        }

        id = null;
        return false;
    }
    
    public static bool IsTestNotFound(this Error error, [MaybeNullWhen(false)] out string id)
    {
        if (error.Type == "TestException:NotFound" && error.Extensions.TryGetValue("id", out var value))
        {
            id = value.ToString()!;
            return true;
        }

        id = null;
        return false;
    }
}
