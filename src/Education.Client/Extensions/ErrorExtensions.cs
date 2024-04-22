using System.Diagnostics.CodeAnalysis;
using Education.Client.Clients;

namespace Education.Client.Extensions;

internal static class ErrorExtensions
{
    public static bool IsExaminationAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string examinationId)
    {
        var found = error.Payload.TryGetValue("id", out var id);
        examinationId = id.GetString();

        return error.Type == "ExaminationAlreadyCreated" && found;
    }

    public static bool IsExaminationAlreadyCompleted(this Error error) =>
        error.Type == "ExaminationAlreadyCompleted";

    public static bool IsExaminationExpired(this Error error) =>
        error.Type == "ExaminationExpired";

    public static bool IsExaminationNotFound(this Error error) =>
        error.Type == "ExaminationNotFound";

    public static bool IsQuizAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string quizId)
    {
        var found = error.Payload.TryGetValue("id", out var id);
        quizId = id.GetString();

        return error.Type == "QuizAlreadyCreated" && found;
    }

    public static bool IsQuizAlreadyCompleted(this Error error) =>
        error.Type == "QuizAlreadyCompleted";

    public static bool IsQuizNotFound(this Error error) =>
        error.Type == "QuizNotFound";

    public static bool IsQuizExpired(this Error error) =>
        error.Type == "QuizExpired";

    public static bool IsFlowNotFound(this Error error) =>
        error.Type == "FlowNotFound";

    public static bool IsDateGuesserAlreadyCreated(this Error error, [MaybeNullWhen(false)] out string testId)
    {
        var found = error.Payload.TryGetValue("id", out var id);
        testId = id.GetString();

        return error.Type == "DateGuesserAlreadyCreated" && found;
    }

    public static bool IsDateGuesserNotFound(this Error error) =>
        error.Type == "DateGuesserNotFound";

    public static bool IsUserNotFound(this Error error) =>
        error.Type == "UserNotFound";
}
