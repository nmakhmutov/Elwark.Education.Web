namespace Education.Client.Features.History.Clients;

public sealed record UserCourseActivityModel(
    CourseLearningStatus Status,
    uint Completeness,
    bool IsBookmarked,
    bool? IsLiked,
    uint EasyExaminations,
    uint HardExaminations
);
