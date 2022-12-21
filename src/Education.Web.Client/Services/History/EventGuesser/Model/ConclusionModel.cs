using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Content;

namespace Education.Web.Client.Services.History.EventGuesser.Model;

public sealed record ConclusionModel(
    uint Score,
    uint MaxScore,
    IInternalMoney[] Rewards,
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
    public bool IsCorrect =>
        CorrectAnswer == UserAnswer;
}
