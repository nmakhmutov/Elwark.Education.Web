namespace Education.Client.Gateways.History.EventGuesser.Models;

public sealed record CheckModel(
    uint Score,
    uint EarnedPoints,
    DateTime X2BonusUntil,
    bool IsComplete
);
