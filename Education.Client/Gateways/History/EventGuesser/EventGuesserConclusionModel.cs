using System;
using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History.EventGuesser
{
    public sealed record EventGuesserConclusionModel(
        uint Score,
        TimeSpan TimeSpent,
        ConclusionQuestionModel[] Questions
    );

    public sealed record ConclusionQuestionModel(
        TopicTitle Topic,
        string Title,
        uint Points,
        uint Bonus,
        uint Score,
        HistoricDate CorrectAnswer,
        HistoricDate UserAnswer
    )
    {
        public bool IsCorrect => CorrectAnswer == UserAnswer;
    };
}
