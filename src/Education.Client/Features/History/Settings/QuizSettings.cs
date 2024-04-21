using Education.Client.Features.History.Clients;

namespace Education.Client.Features.History.Settings;

public sealed record QuizSettings(EpochType Epoch)
{
    public static readonly QuizSettings Empty = new(EpochType.None);
}
