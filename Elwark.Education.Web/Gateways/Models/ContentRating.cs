using MudBlazor;

namespace Elwark.Education.Web.Gateways.Models
{
    public record ContentRating(uint Likes, uint Dislikes, double Ranking)
    {
        public Color Color => Ranking switch
        {
            > 50 => Color.Success,
            > 0 and < 50 => Color.Error,
            _ => Color.Primary
        };
    }

    public sealed record UserContentRating(uint Likes, uint Dislikes, double Ranking, bool? IsLiked)
        : ContentRating(Likes, Dislikes, Ranking);
}
