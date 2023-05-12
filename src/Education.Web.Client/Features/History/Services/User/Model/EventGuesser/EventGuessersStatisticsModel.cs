using Education.Web.Client.Features.History.Services.EventGuesser.Model;

namespace Education.Web.Client.Features.History.Services.User.Model.EventGuesser;

public sealed record EventGuessersStatisticsModel(
    EventGuessersStatisticsModel.EventGuesserModel SmallEventGuesser,
    EventGuessersStatisticsModel.EventGuesserModel MediumEventGuesser,
    EventGuessersStatisticsModel.EventGuesserModel LargeEventGuesser,
    EventGuessersStatisticsModel.ProgressModel[] Daily,
    EventGuessersStatisticsModel.ProgressModel[] Monthly
)
{
    public sealed record EventGuesserModel(uint Tests, ScoreModel Score);

    public sealed record ProgressModel(DateOnly Date, uint Small, uint Medium, uint Large);
}
