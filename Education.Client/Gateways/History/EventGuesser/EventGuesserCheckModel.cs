using System;

namespace Education.Client.Gateways.History.EventGuesser
{
    public sealed record EventGuesserCheckModel(
        uint Score,
        uint EarnedPoints,
        DateTime X2BonusUntil,
        bool IsComplete
    );
}
