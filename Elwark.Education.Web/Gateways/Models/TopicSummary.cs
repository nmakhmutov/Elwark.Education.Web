namespace Elwark.Education.Web.Gateways.Models
{
    public record TopicSummary(
        string Id,
        string Title,
        string Overview,
        string Image,
        bool IsFavorite,
        ContentRating Rating,
        TopicProgress? Progress
    );
}
