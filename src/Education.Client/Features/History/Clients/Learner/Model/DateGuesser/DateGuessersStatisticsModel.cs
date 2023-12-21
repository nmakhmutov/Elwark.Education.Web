using Education.Client.Features.History.Clients.DateGuesser.Model;

namespace Education.Client.Features.History.Clients.Learner.Model.DateGuesser;

public sealed record DateGuessersStatisticsModel(
    DateGuessersStatisticsModel.DateGuesserModel SmallDateGuesser,
    DateGuessersStatisticsModel.DateGuesserModel MediumDateGuesser,
    DateGuessersStatisticsModel.DateGuesserModel LargeDateGuesser,
    DateGuessersStatisticsModel.ProgressModel[] Daily,
    DateGuessersStatisticsModel.ProgressModel[] Monthly
)
{
    public sealed record DateGuesserModel(uint Tests, ScoreModel Score);

    public sealed record ProgressModel(DateOnly Date, uint Small, uint Medium, uint Large);
}
