namespace Elwark.Education.Web.Gateways.Models.Content
{
    public sealed record UserContentRating(double Value, uint Votes, bool? IsLiked)
        :ContentRating(Value, Votes);
}
