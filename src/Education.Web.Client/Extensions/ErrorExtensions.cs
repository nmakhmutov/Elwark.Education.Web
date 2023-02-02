using System.Diagnostics.CodeAnalysis;
using Education.Web.Client.Http;

namespace Education.Web.Client.Extensions;

internal static class ErrorExtensions
{
    public static bool IsTestAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string id)
    {
        id = error.Id;
        return error.Type == "TestException:AlreadyCreated" && !string.IsNullOrEmpty(error.Id);
    }

    public static bool IsTestAlreadyCompleted(this Error error) =>
        error.Type == "TestException:AlreadyCompleted";

    public static bool IsTestNotFound(this Error error) =>
        error.Type == "TestException:NotFound";

    public static bool IsEventGuesserNotFound(this Error error) =>
        error.Type == "EventGuesserException:NotFound";

    public static bool IsUserNotFound(this Error error) =>
        error.Type == "UserException:NotFound";
}
