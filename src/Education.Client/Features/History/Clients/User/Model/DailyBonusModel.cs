using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record DailyBonusModel(bool IsCollectable, DateTime? NextTimeAt, InternalMoneyModel[] Rewards);
