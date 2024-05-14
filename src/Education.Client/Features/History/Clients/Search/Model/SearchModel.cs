using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients.Search.Model;

public sealed record SearchModel
{
    public SearchModel(string id, string title, string overview, ImageBundleModel image, string category)
    {
        Id = id;
        Title = title;
        Overview = overview;
        Image = image;
        Category = category;

        (ContentHref, CategoryHref) = category switch
        {
            "Article" => (HistoryUrl.Content.Article(id), HistoryUrl.Content.Articles()),
            "Course" => (HistoryUrl.Content.Course(id), HistoryUrl.Content.Courses()),
            _ => (HistoryUrl.Root, HistoryUrl.Root)
        };
    }

    public string Id { get; private set; }

    public string Title { get; }

    public string Overview { get; }

    public ImageBundleModel Image { get; }

    public string Category { get; }

    public string CategoryHref { get; }

    public string ContentHref { get; }
}
