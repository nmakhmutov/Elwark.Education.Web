using System.Text.Json.Serialization;

namespace Education.Client.Features.History.Clients.User.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "_t"),
 JsonDerivedType(typeof(CompletedModel), "completed"),
 JsonDerivedType(typeof(LadderModel), "ladder"),
 JsonDerivedType(typeof(ProgressiveModel), "progressive")]
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
        Reward[] Rewards
    ) : Achievement(Id, Title, Description, ImageUrl);

    public sealed record ProgressiveModel(
        string Id,
        string Title,
        string Description,
        string ImageUrl,
        uint Completeness,
        Reward[] Rewards
    ) : Achievement(Id, Title, Description, ImageUrl);
}
