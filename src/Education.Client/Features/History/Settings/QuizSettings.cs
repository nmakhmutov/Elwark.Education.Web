using Education.Client.Features.History.Clients;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Settings;

public sealed record QuizSettings(EpochType Epoch, DifficultyType? Difficulty)
{
    public static readonly QuizSettings Empty = new(EpochType.None, null);
}
