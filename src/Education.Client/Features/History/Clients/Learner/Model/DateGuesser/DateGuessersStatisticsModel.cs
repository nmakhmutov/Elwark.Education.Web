using Education.Client.Features.History.Clients.DateGuesser.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.DateGuesser;

public sealed record DateGuessersStatisticsModel(
    DateGuessersStatisticsModel.DateGuesserModel Small,
    DateGuessersStatisticsModel.DateGuesserModel Medium,
    DateGuessersStatisticsModel.DateGuesserModel Large,
    DateGuesserProgressModel[] Daily,
    DateGuesserProgressModel[] Monthly
)
{
    public sealed record DateGuesserModel(uint Tests, ScoreModel Score);
}
