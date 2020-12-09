using Elwark.Education.Web.Services.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTestQuestionModel(
        string Id,
        QuestionType Type,
        string Title,
        bool IsAnswered,
        string[] Options
    );
}