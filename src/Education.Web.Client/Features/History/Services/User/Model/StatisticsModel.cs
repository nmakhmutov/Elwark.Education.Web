using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.User.Model.Test;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record StatisticsModel(
    StatisticsModel.QuizModel EasyQuiz,
    StatisticsModel.QuizModel HardQuiz,
    StatisticsModel.EventGuesserModel SmallEventGuesser,
    StatisticsModel.EventGuesserModel MediumEventGuesser,
    StatisticsModel.EventGuesserModel LargeEventGuesser,
    StatisticsModel.AccountingModel[] Accounting,
    StatisticsModel.ProgressModel[] Daily,
    StatisticsModel.ProgressModel[] Monthly
)
{
    public sealed record QuizModel(NumberOfTestsModel NumberOfTests, ScoreModel Score);

    public sealed record EventGuesserModel(uint Tests, Services.EventGuesser.Model.ScoreModel Score);

    public sealed record AccountingModel(string Currency, BudgetModel[] Finance);

    public sealed record ProgressModel(
        DateOnly Date,
        uint Total,
        ProgressModel.TestProgressModel Test,
        ProgressModel.EventGuesserProgressModel EventGuesser
    )
    {
        public sealed record TestProgressModel(uint Easy, uint Hard);

        public sealed record EventGuesserProgressModel(uint Small, uint Medium, uint Large);
    }
}
