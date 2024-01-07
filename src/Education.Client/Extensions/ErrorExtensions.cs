using System.Diagnostics.CodeAnalysis;
using Education.Client.Clients;

namespace Education.Client.Extensions;

internal static class ErrorExtensions
{
    public static bool IsExaminationAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string examinationId)
    {
        var found = error.Payload.TryGetValue("id", out var id);
        examinationId = id.GetString();

        return error.Type == "Examination_AlreadyCreated" && found;
    }

    public static bool IsExaminationAlreadyCompleted(this Error error) =>
        error.Type == "Examination_AlreadyCompleted";

    public static bool IsExaminationNotFound(this Error error) =>
        error.Type == "Examination_NotFound";

    public static bool IsExaminationExpired(this Error error) =>
        error.Type == "Examination_Expired";

    public static bool IsQuizAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string quizId)
    {
        var found = error.Payload.TryGetValue("id", out var id);
        quizId = id.GetString();

        return error.Type == "Quiz_AlreadyCreated" && found;
    }

    public static bool IsQuizAlreadyCompleted(this Error error) =>
        error.Type == "Quiz_AlreadyCompleted";

    public static bool IsQuizNotFound(this Error error) =>
        error.Type == "Quiz_NotFound";

    public static bool IsQuizExpired(this Error error) =>
        error.Type == "Quiz_Expired";

    public static bool IsFlowNotFound(this Error error) =>
        error.Type == "Flow_NotFound";

    public static bool IsDateGuesserAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string testId)
    {
        var found = error.Payload.TryGetValue("id", out var id);
        testId = id.GetString();

        return error.Type == "DateGuesser_AlreadyCreated" && found;
    }

    public static bool IsDateGuesserNotFound(this Error error) =>
        error.Type == "DateGuesser_NotFound";

    public static bool IsOrderNotFound(this Error error) =>
        error.Type == "Ordering_NotFound";

    public static bool IsUserNotFound(this Error error) =>
        error.Type == "User_NotFound";
}
