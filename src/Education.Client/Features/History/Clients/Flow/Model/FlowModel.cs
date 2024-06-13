using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow.Model;

public sealed record FlowModel(StreakModel Streak, TrackModel Track, Question Question, Reward[] Bank);
