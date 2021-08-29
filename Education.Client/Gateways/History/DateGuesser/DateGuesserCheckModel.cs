using System;

namespace Education.Client.Gateways.History.DateGuesser
{
    public sealed record DateGuesserCheckModel(
        uint TotalPoints,
        uint EarnedPoints,
        DateTime X2BonusUntil,
        bool IsComplete
    );
}
