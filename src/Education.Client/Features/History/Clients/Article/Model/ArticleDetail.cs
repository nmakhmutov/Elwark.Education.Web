using Education.Client.Models.Content;
using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.History.Clients.Article.Model;

public abstract record ArticleDetail(string Id, string Title, string Description, string ImageUrl)
{
    public sealed record BattleModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        HistoricalDateModel? Started,
        HistoricalDateModel? Finished,
        MarkupString Location,
        MarkupString Result,
        ImageModel? Map,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt,
        ConflictPartyModel[] ConflictParties
    ) : ArticleDetail(Id, Title, Description, ImageUrl);

    public sealed record EmpireModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
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
    ) : ArticleDetail(Id, Title, Description, ImageUrl);

    public sealed record GeneralModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt
    ) : ArticleDetail(Id, Title, Description, ImageUrl);

    public sealed record PersonModel(
        string Id,
        EpochType Epoch,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        PersonBirthdayModel? Born,
        PersonBirthdayModel? Died,
        TimeSpan TimeToRead,
        ContentRatingModel Rating,
        DateTime CreatedAt,
        PersonalDetailModel[] Details
    ) : ArticleDetail(Id, Title, Description, ImageUrl);
}
