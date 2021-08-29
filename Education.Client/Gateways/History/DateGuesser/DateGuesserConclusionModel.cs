using System;
using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History.DateGuesser
{
    public sealed record DateGuesserConclusionModel(
        uint TotalPoints,
        TimeSpan TimeSpent,
        ConclusionQuestionModel[] Questions
    );

    public sealed record ConclusionQuestionModel(
        TopicTitle Topic,
        string Title,
        uint RawPoints,
        uint BonusPoints,
        uint TotalPoints,
        HistoricDate CorrectAnswer,
        HistoricDate UserAnswer
    )
    {
        public bool IsCorrect => CorrectAnswer == UserAnswer;
    };
}
