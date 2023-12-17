namespace Education.Web.Client.Features.History.Clients.Search.Model;

public sealed record SearchModel
{
    public SearchModel(string id, string title, string overview, string imageUrl, string category)
    {
        Id = id;
        Title = title;
        Overview = overview;
        ImageUrl = imageUrl;
        Category = category;

        (ContentHref, CategoryHref) = category switch
        {
            "Article" => (HistoryUrl.Content.Article(Id), HistoryUrl.Content.Articles()),
            "Course" => (HistoryUrl.Content.Course(Id), HistoryUrl.Content.Courses()),
            _ => (HistoryUrl.Root, HistoryUrl.Root)
        };
    }

    public string Id { get; }

    public string Title { get; }

    public string Overview { get; }

    public string ImageUrl { get; }

    public string Category { get; }

    public string CategoryHref { get; }

    public string ContentHref { get; }
}
