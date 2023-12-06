using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services.Course.Model;

public sealed record CourseModel(
    string Id,
    string Title,
    string ImageUrl,
    string Description,
    CourseModel.CourseDetailsModel Details,
    UserArticleOverviewModel[] Articles
)
{
    public sealed record CourseDetailsModel(uint Learners, TimeSpan TimeToRead, ContentRatingModel Rating);
}
