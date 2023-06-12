using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public abstract record Achievement(string Id, string Title, string Description, string IconUrl)
{
    public sealed record CompletedModel(
        string Id,
        string Title,
        string Description,
        string IconUrl,
        DateTime UnlockedAt,
        double GlobalUnlockedPercent
    ) : Achievement(Id, Title, Description, IconUrl);

    public sealed record LadderModel(
        string Id,
        string Title,
        string Description,
        string IconUrl,
        uint Level,
        uint Score,
        uint Threshold,
        uint Completeness,
        InternalMoneyModel[] Rewards
    ) : Achievement(Id, Title, Description, IconUrl);

    public sealed record ProgressiveModel(
        string Id,
        string Title,
        string Description,
        string IconUrl,
        uint Completeness,
        InternalMoneyModel[] Rewards
    ) : Achievement(Id, Title, Description, IconUrl);
}
