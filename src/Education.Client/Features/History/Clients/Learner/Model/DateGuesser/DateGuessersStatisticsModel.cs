using Education.Client.Features.History.Clients.DateGuesser.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.DateGuesser;

public sealed record DateGuessersStatisticsModel(
    DateGuessersStatisticsModel.DateGuesserModel SmallDateGuesser,
    DateGuessersStatisticsModel.DateGuesserModel MediumDateGuesser,
    DateGuessersStatisticsModel.DateGuesserModel LargeDateGuesser,
    DateGuesserProgressModel[] Daily,
    DateGuesserProgressModel[] Monthly
)
{
    public sealed record DateGuesserModel(uint Tests, ScoreModel Score);

}