using Education.Web.Client.Services.Model.Content;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Services.History.Topic.Model;

public abstract record TopicDetail(
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
    ) : TopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
    
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
    ) : TopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
    
    public sealed record GeneralModel(
        string Id,
        string Title,
        string Description,
        MarkupString Content,
        string ImageUrl,
        EpochType Epoch,
        string[] Tags
    ) : TopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
    
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
    ) : TopicDetail(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
}
