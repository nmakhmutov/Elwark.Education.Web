using Education.Web.Client.Models.Content;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Features.History.Services.Article.Model;

public abstract record ArticleDetail(
    string Id,
    string Title,
    string Description,
    MarkupString Content,
    string ImageUrl,
    EpochType Epoch,
    ContentRatingModel Rating
)
{
    public sealed record BattleModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        EpochType Epoch,
        HistoricalDateModel? Started,
        HistoricalDateModel? Finished,
        MarkupString Location,
        MarkupString Result,
        ImageModel? Map,
        ContentRatingModel Rating,
        ConflictPartyModel[] ConflictParties
    ) : ArticleDetail(Id, Title, Description, Content, ImageUrl, Epoch, Rating);

    public sealed record EmpireModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        ImageModel? Flag,
        ImageModel? Map,
        EpochType Epoch,
        HistoricalDateModel? Founded,
        HistoricalDateModel? Dissolved,
        uint? Duration,
        uint MaxArea,
        uint MaxPopulation,
        ContentRatingModel Rating
    ) : ArticleDetail(Id, Title, Description, Content, ImageUrl, Epoch, Rating);

    public sealed record GeneralModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        EpochType Epoch,
        ContentRatingModel Rating
    ) : ArticleDetail(Id, Title, Description, Content, ImageUrl, Epoch, Rating);

    public sealed record PersonModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        EpochType Epoch,
        PersonBirthdayModel? Born,
        PersonBirthdayModel? Died,
        ContentRatingModel Rating,
        PersonalDetailModel[] Details
    ) : ArticleDetail(Id, Title, Description, Content, ImageUrl, Epoch, Rating);
}
