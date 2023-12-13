using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Settings;

public sealed record QuizSettings(EpochType Epoch, DifficultyType? Difficulty)
{
    public static readonly QuizSettings Empty = new(EpochType.None, null);
}
