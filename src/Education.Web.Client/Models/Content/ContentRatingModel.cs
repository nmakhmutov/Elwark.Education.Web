namespace Education.Web.Client.Models.Content;

public sealed record ContentRatingModel(double Rating, uint Votes)
{
    public double Stars =>
        Math.Round(Rating / 20, 1);
}
