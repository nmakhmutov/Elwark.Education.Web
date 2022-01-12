namespace Education.Client.Gateways.Models;

public sealed record TimeSpent(TimeSpan Total, TimeSpan Average, TimeSpan Min, TimeSpan Max);
