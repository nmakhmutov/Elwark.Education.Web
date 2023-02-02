using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public abstract record Achievement(string Title, string Description, string IconUrl)
{
    public sealed record CompletedModel(string Title, string Description, string IconUrl, DateTime CompletedAt)
        : Achievement(Title, Description, IconUrl);

    public sealed record LadderModel(
        string Title,
        string Description,
        string IconUrl,
        uint Level,
        uint Score,
        uint Threshold,
        uint Completeness,
        IInternalMoney[] Rewards
    ) : Achievement(Title, Description, IconUrl);

    public sealed record ProgressiveModel(
        string Title,
        string Description,
        string IconUrl,
        uint Completeness,
        IInternalMoney[] Rewards
    ) : Achievement(Title, Description, IconUrl);
}
