using Education.Web.Gateways.Models.Content;

namespace Education.Web.Gateways.History.EventGuesser.Model;

public sealed record ConclusionModel(
    uint Score,
    TimeSpan TimeSpent,
    QuestionModel[] Questions
);

public sealed record QuestionModel(
    TopicTitleModel Topic,
    string Title,
    uint Points,
    uint Bonus,
    uint Score,
    HistoricalDateModel CorrectAnswer,
    HistoricalDateModel UserAnswer
)
{
    public bool IsCorrect => CorrectAnswer == UserAnswer;
}
