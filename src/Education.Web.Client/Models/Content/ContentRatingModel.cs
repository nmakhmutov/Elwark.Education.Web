namespace Education.Web.Client.Models.Content;

public sealed record ContentRatingModel(double Score, uint Votes)
{
    public double Stars =>
        Math.Round(Score / 20, 1);
}
