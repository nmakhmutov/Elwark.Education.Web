using Elwark.Education.Web.Gateways.History.Epoch;
using Elwark.Education.Web.Gateways.Models.Content;

namespace Elwark.Education.Web.Gateways.History.Topic
{
    internal abstract record TopicDetail(
        string Id,
        string Title,
        string Description,
        string Image,
        EpochType Epoch,
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
        Chapter[] Content,
        string[] Occupations,
        Characteristic[] Characteristics
    ) : TopicDetail(Id, Title, Description, Image, Epoch, Content);
    
    internal sealed record EventTopicDetail(
        string Id,
        string Title,
        string Description,
        string Image,
        EpochType Epoch,
        HistoricDate? Started,
        HistoricDate? Ended,
        Chapter[] Content
    ) : TopicDetail(Id, Title, Description, Image, Epoch, Content);
}
