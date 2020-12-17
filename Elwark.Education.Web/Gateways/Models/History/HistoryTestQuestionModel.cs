using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTestQuestionModel(
        string Id,
        QuestionType Type,
        string Title,
        string? Image,
        bool IsAnswered,
        AnswerOption[] Options
    );
    
    public sealed record AnswerOption(int Number, string Value, AnswerOptionType Type);
}