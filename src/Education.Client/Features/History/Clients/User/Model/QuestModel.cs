using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record QuestModel(
    string Id,
    string Title,
    string Description,
    string ImageUrl,
    uint Score,
    uint Threshold,
    QuestStatus Status,
    DateTime ExpiresAt,
    InternalMoneyModel[] Rewards
);
