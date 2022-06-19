using Education.Web.Gateways.Models.Content;

namespace Education.Web.Gateways.History.Topics.Model;

internal abstract record HistoryTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string ImageUrl,
    EpochType Epoch,
    string[] Tags,
    ChapterModel[] Chapters
);

internal sealed record EmpireTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string ImageUrl,
    string? FlagUrl,
    string? MapUrl,
    EpochType Epoch,
    HistoricalDateModel? Founded,
    HistoricalDateModel? Dissolved,
    uint? Duration,
    uint MaxArea,
    uint MaxPopulation,
    string[] Tags,
    ChapterModel[] Chapters
) : HistoryTopicDetailModel(Id, Title, Description, ImageUrl, Epoch, Tags, Chapters);

internal sealed record EventTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string ImageUrl,
    EpochType Epoch,
    HistoricalDateModel? Started,
    HistoricalDateModel? Finished,
    string[] Tags,
    ChapterModel[] Chapters
) : HistoryTopicDetailModel(Id, Title, Description, ImageUrl, Epoch, Tags, Chapters);

internal sealed record PersonTopicDetailModel(
    string Id,
    string Title,
    string Description,
    string ImageUrl,
    EpochType Epoch,
    PersonBirthdayModel? Born,
    PersonBirthdayModel? Died,
    string[] Tags,
    ChapterModel[] Chapters,
    CharacteristicModel[] Characteristics
) : HistoryTopicDetailModel(Id, Title, Description, ImageUrl, Epoch, Tags, Chapters);

