namespace Education.Web.Client.Features.History.Services.Search.Model;

public sealed record SearchModel(string Id, string Title, string Overview, string ImageUrl, string Category)
{
    public string Href =>
        Category switch
        {
            "Article" => HistoryUrl.Content.Article(Id),
            _ => HistoryUrl.Root
        };
}
