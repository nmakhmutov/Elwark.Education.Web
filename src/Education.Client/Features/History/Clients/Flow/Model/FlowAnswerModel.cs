using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow.Model;

public sealed record FlowAnswerModel(StreakModel Streak, TrackModel Track, AnswerResult Answer, Reward[] Bank);
