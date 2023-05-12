using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services.Course.Model;

public sealed record CourseModel(
    string Id,
    string Title,
    string ImageUrl,
    string Description,
    ContentRatingModel Rating,
    UserCourseActivityModel UserActivity,
    UserArticleOverviewModel[] Articles
);
