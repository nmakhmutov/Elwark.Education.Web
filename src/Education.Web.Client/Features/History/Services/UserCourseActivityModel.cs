namespace Education.Web.Client.Features.History.Services;

public sealed record UserCourseActivityModel(
    CourseLearningStatus Status,
    uint Completeness,
    bool IsBookmarked,
    bool? IsLiked,
    uint EasyExaminations,
    uint HardExaminations
);
