using System.Diagnostics.CodeAnalysis;
using Education.Web.Client.Http;

namespace Education.Web.Client.Extensions;

internal static class ErrorExtensions
{
    public static bool IsTestAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string id)
    {
        id = error.Id;
        return error.Type == "Test:AlreadyCreated" && !string.IsNullOrEmpty(error.Id);
    }

    public static bool IsTestAlreadyCompleted(this Error error) =>
        error.Type == "Test:AlreadyCompleted";

    public static bool IsFlowNotFound(this Error error) =>
        error.Type == "Flow:NotFound";

    public static bool IsTestNotFound(this Error error) =>
        error.Type == "Test:NotFound";

    public static bool IsOrderNotFound(this Error error) =>
        error.Type == "Ordering:NotFound";

    public static bool IsEventGuesserNotFound(this Error error) =>
        error.Type == "EventGuesser:NotFound";

    public static bool IsUserNotFound(this Error error) =>
        error.Type == "User:NotFound";
}
