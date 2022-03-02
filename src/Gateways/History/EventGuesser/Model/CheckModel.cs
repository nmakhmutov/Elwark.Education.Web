namespace Education.Web.Gateways.History.EventGuesser.Model;

public sealed record CheckModel(
    uint Score,
    uint EarnedPoints,
    DateTime X2BonusUntil,
    bool IsComplete
);
