using Elwark.Education.Web.Gateways.Models.Content;

namespace Elwark.Education.Web.Gateways.Models.Test
{
    public sealed record TestQuestion(
        string Id,
        QuestionType Type,
        string Title,
        string? Image,
        bool IsAnswered,
        TopicTitle Topic,
        AnswerOption[] Options
    );
}
