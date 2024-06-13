namespace Education.Client.Features.History.Clients.Flow.Model;

public sealed record TrackModel(uint Current, uint Threshold, Reward[] Rewards);
