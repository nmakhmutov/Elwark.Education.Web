namespace Education.Client.Gateways.Models.Content;

public sealed record UserContentRating(double Rating, uint Votes, bool? IsLiked)
    :ContentRating(Rating, Votes);
