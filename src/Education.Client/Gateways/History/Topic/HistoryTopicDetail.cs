using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History.Topic;

internal abstract record HistoryTopicDetail(
    string Id,
    string Title,
    string Description,
    string Image,
    EpochType Epoch,
    string[] Tags,
    Chapter[] Chapters
);

internal sealed record PersonTopicDetail(
    string Id,
    string Title,
    string Description,
    string Image,
    EpochType Epoch,
    HistoricalPersonBirthday? Born,
    HistoricalPersonBirthday? Died,
    string[] Tags,
    Chapter[] Chapters,
    Characteristic[] Characteristics
) : HistoryTopicDetail(Id, Title, Description, Image, Epoch, Tags, Chapters);

internal sealed record EventTopicDetail(
    string Id,
    string Title,
    string Description,
    string Image,
    EpochType Epoch,
    HistoricalDate? Started,
    HistoricalDate? Finished,
    string[] Tags,
    Chapter[] Chapters
) : HistoryTopicDetail(Id, Title, Description, Image, Epoch, Tags, Chapters);

internal sealed record EmpireTopicDetail(
    string Id,
    string Title,
    string Description,
    string Image,
    EpochType Epoch,
    HistoricalDate? Founded,
    HistoricalDate? Dissolved,
    uint MaxArea,
    uint MaxPopulation,
    string[] Tags,
    Chapter[] Chapters
) : HistoryTopicDetail(Id, Title, Description, Image, Epoch, Tags, Chapters);
