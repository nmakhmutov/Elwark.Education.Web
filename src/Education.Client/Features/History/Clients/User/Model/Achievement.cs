using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public abstract record Achievement(string Id, string Title, string Description, string ImageUrl)
{
    public sealed record CompletedModel(
        string Id,
        string Title,
        string Description,
        string ImageUrl,
        DateTime UnlockedAt,
        double GlobalUnlockedPercent
    ) : Achievement(Id, Title, Description, ImageUrl);

    public sealed record LadderModel(
        string Id,
        string Title,
        string Description,
        string ImageUrl,
        uint Level,
        uint Score,
        uint Threshold,
        uint Completeness,
        InternalMoneyModel[] Rewards
    ) : Achievement(Id, Title, Description, ImageUrl);

    public sealed record ProgressiveModel(
        string Id,
        string Title,
        string Description,
        string ImageUrl,
        uint Completeness,
        InternalMoneyModel[] Rewards
    ) : Achievement(Id, Title, Description, ImageUrl);
}
