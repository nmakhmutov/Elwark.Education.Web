using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History.EventGuesser.Models;

public sealed record ConclusionModel(
    uint Score,
    TimeSpan TimeSpent,
    QuestionModel[] Questions
);

public sealed record QuestionModel(
    TopicTitle Topic,
    string Title,
    uint Points,
    uint Bonus,
    uint Score,
    HistoricalDate CorrectAnswer,
    HistoricalDate UserAnswer
)
{
    public bool IsCorrect => CorrectAnswer == UserAnswer;
}
