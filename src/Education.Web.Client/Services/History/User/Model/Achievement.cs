using Education.Web.Client.Services.Model;

namespace Education.Web.Client.Services.History.User.Model;

public abstract record Achievement(string Category, string Name, string Title, string Description)
{
    public sealed record CompletedModel(
        string Category,
        string Name,
        string Title,
        string Description,
        DateTime CompletedAt
    ) : Achievement(Category, Name, Title, Description);

    public sealed record LadderModel(
        string Category,
        string Name,
        string Title,
        string Description,
        uint Level,
        uint Score,
        uint Threshold,
        uint Completeness,
        IInternalMoney[] Rewards
    ) : Achievement(Category, Name, Title, Description);

    public sealed record ProgressiveModel(
        string Category,
        string Name,
        string Title,
        string Description,
        uint Completeness,
        IInternalMoney[] Rewards
    ) : Achievement(Category, Name, Title, Description);
}
