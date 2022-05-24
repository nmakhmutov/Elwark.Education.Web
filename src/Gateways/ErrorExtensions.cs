using System.Diagnostics.CodeAnalysis;

namespace Education.Web.Gateways;

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

    public static bool IsTestAlreadyCompleted(this Error error) =>
        error.Type == "TestException:AlreadyCompleted";

    public static bool IsTestNotFound(this Error error) =>
        error.Type == "TestException:NotFound";

    public static bool IsEventGuesserNotFound(this Error error) =>
        error.Type == "EventGuesserException:NotFound";
}
