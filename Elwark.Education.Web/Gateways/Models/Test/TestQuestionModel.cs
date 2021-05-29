namespace Elwark.Education.Web.Gateways.Models.Test
{
    public sealed record TestQuestionModel(
        string Id,
        QuestionType Type,
        string Title,
        string? Image,
        bool IsAnswered,
        AnswerOption[] Options
    );
}
