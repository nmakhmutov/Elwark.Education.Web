using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History.Topic;

internal abstract record TopicDetail(
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
    HistoricalPersonDate? Born,
    HistoricalPersonDate? Died,
    string[] Tags,
    Chapter[] Chapters,
    Characteristic[] Characteristics
) : TopicDetail(Id, Title, Description, Image, Epoch, Tags, Chapters);

internal sealed record EventTopicDetail(
    string Id,
    string Title,
    string Description,
    string Image,
    EpochType Epoch,
    HistoricDate? Started,
    HistoricDate? Finished,
    string[] Tags,
    Chapter[] Chapters
) : TopicDetail(Id, Title, Description, Image, Epoch, Tags, Chapters);

internal sealed record EmpireTopicDetail(
    string Id,
    string Title,
    string Description,
    string Image,
    EpochType Epoch,
    HistoricDate? Founded,
    HistoricDate? Dissolved,
    uint MaxArea,
    uint MaxPopulation,
    string[] Tags,
    Chapter[] Chapters
) : TopicDetail(Id, Title, Description, Image, Epoch, Tags, Chapters);
