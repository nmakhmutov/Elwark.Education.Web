using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients.Course.Model;

public sealed record CourseModel(
    string Id,
    string Title,
    string Description,
    ImageModel Image,
    CourseModel.CourseDetailsModel Details,
    UserArticleOverviewModel[] Articles
)
{
    public sealed record CourseDetailsModel(uint Learners, TimeSpan TimeToRead, double Popularity);
}
