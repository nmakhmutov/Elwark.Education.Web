using Education.Web.Client.Features.History.Services.Test.Model;
using Education.Web.Client.Features.History.Services.User.Model.Test;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record StatisticsModel(
    StatisticsModel.TestModel EasyTest,
    StatisticsModel.TestModel HardTest,
    StatisticsModel.TestModel MixedTest,
    StatisticsModel.EventGuesserModel SmallEventGuesser,
    StatisticsModel.EventGuesserModel MediumEventGuesser,
    StatisticsModel.EventGuesserModel LargeEventGuesser,
    BudgetModel[] Silver,
    StatisticsModel.ProgressModel[] Daily,
    StatisticsModel.ProgressModel[] Monthly
)
{
    public sealed record TestModel(NumberOfTestsModel NumberOfTests, ScoreModel Score);

    public sealed record EventGuesserModel(uint Tests, Services.EventGuesser.Model.ScoreModel Score);

    public sealed record ProgressModel(
        DateOnly Date,
        uint Total,
        ProgressModel.TestProgressModel Test,
        ProgressModel.EventGuesserProgressModel EventGuesser
    )
    {
        public sealed record TestProgressModel(uint Easy, uint Hard, uint Mixed);

        public sealed record EventGuesserProgressModel(uint Small, uint Medium, uint Large);
    }
}
