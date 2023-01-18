using Education.Web.Client.Services.Model.Content;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Services.History.Topic.Model;

public abstract record HistoryTopicDetail(
    string Id,
    string Title,
    string Description,
    MarkupString Content,
    string ImageUrl,
    EpochType Epoch,
    string[] Tags
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
        string[] Tags,
        ConflictPartyModel[] ConflictParties
    ) : HistoryTopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
    
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
        string[] Tags
    ) : HistoryTopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
    
    public sealed record GeneralModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        EpochType Epoch,
        string[] Tags
    ) : HistoryTopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
    
    public sealed record PersonModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        EpochType Epoch,
        PersonBirthdayModel? Born,
        PersonBirthdayModel? Died,
        string[] Tags,
        PersonalDetailModel[] Details
    ) : HistoryTopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
}
