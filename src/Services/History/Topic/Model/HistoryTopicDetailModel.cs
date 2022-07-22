using Education.Web.Services.Model;

namespace Education.Web.Services.History.Topic.Model;

public abstract record HistoryTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string Content,
    string ImageUrl,
    EpochType Epoch,
    string[] Tags
);

public sealed record BattleTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string Content,
    string ImageUrl,
    EpochType Epoch,
    HistoricalDateModel? Started,
    HistoricalDateModel? Finished,
    string Location,
    string Result,
    ImageModel? Map,
    string[] Tags,
    ConflictPartyModel[] ConflictParties
) : HistoryTopicDetailModel(Id, Title, Description, Content, ImageUrl, Epoch, Tags);

public sealed record EmpireTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string Content,
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
) : HistoryTopicDetailModel(Id, Title, Description, Content, ImageUrl, Epoch, Tags);

public sealed record GeneralTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string Content,
    string ImageUrl,
    EpochType Epoch,
    string[] Tags
) : HistoryTopicDetailModel(Id, Title, Description, Content, ImageUrl, Epoch, Tags);

public sealed record PersonTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string Content,
    string ImageUrl,
    EpochType Epoch,
    PersonBirthdayModel? Born,
    PersonBirthdayModel? Died,
    string[] Tags,
    PersonalDetailModel[] Details
) : HistoryTopicDetailModel(Id, Title, Description, Content, ImageUrl, Epoch, Tags);
