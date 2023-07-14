using System.Diagnostics.CodeAnalysis;
using Education.Web.Client.Http;

namespace Education.Web.Client.Extensions;

internal static class ErrorExtensions
{
    public static bool IsQuizAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string id)
    {
        id = error.Id;
        return error.Type == "Quiz:AlreadyCreated" && !string.IsNullOrEmpty(error.Id);
    }

    public static bool IsQuizAlreadyCompleted(this Error error) =>
        error.Type == "Quiz:AlreadyCompleted";

    public static bool IsQuizNotFound(this Error error) =>
        error.Type == "Quiz:NotFound";

    public static bool IsFlowNotFound(this Error error) =>
        error.Type == "Flow:NotFound";

    public static bool IsDateGuesserAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string id)
    {
        id = error.Id;
        return error.Type == "DateGuesser:AlreadyCreated" && !string.IsNullOrEmpty(error.Id);
    }
    
    public static bool IsDateGuesserNotFound(this Error error) =>
        error.Type == "DateGuesser:NotFound";

    public static bool IsOrderNotFound(this Error error) =>
        error.Type == "Ordering:NotFound";

    public static bool IsUserNotFound(this Error error) =>
        error.Type == "User:NotFound";
}
