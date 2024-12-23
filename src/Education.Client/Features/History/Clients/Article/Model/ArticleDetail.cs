using System.Text.Json.Serialization;
using Education.Client.Models.Content;
using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.History.Clients.Article.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(GeneralModel), "general"),
 JsonDerivedType(typeof(BattleModel), "battle"),
 JsonDerivedType(typeof(EmpireModel), "empire"),
 JsonDerivedType(typeof(PersonModel), "person")]
public abstract record ArticleDetail(string Id, string Title, string Description, ImageBundleModel Image)
{
    public sealed record BattleModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        ImageBundleModel Image,
        HistoricalDateModel? Started,
        HistoricalDateModel? Finished,
        MarkupString Location,
        MarkupString Result,
        FactionModel FactionA,
        FactionModel FactionB,
        ImageModel? Map,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt
    ) : ArticleDetail(Id, Title, Description, Image);

    public sealed record EmpireModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        ImageBundleModel Image,
        ImageModel? Flag,
        ImageModel? Map,
        HistoricalDateModel? Founded,
        HistoricalDateModel? Dissolved,
        uint? Duration,
        uint MaxArea,
        uint MaxPopulation,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt
    ) : ArticleDetail(Id, Title, Description, Image);

    public sealed record GeneralModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        ImageBundleModel Image,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt
    ) : ArticleDetail(Id, Title, Description, Image);

    public sealed record PersonModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        ImageBundleModel Image,
        PersonBirthdayModel? Born,
        PersonBirthdayModel? Died,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt,
        PersonalDetailModel[] Details
    ) : ArticleDetail(Id, Title, Description, Image);
}
