using Education.Client.Gateways.Models.Statistics;

namespace Education.Client.Gateways.History.Users.Model;

public sealed record EventGuesserStatisticsModel(
    uint Tests,
    uint Score,
    uint Points,
    uint Bonus,
    uint Questions,
    uint Correct,
    uint Incorrect,
    EventGuesserStatisticsModel.Contrast RangeContrast
)
{
    public sealed record Contrast(
        DateOnly Starts,
        DateOnly Ends,
        ContrastModel<uint> Tests,
        ContrastModel<uint> Score,
        ContrastModel<uint> Bonus,
        ContrastModel<uint> Points,
        ContrastModel<uint> Questions,
        ContrastModel<uint> Correct,
        ContrastModel<uint> Incorrect
    );
    
}
