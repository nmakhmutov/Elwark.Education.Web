namespace Education.Client.Features.History.Clients;

public sealed record UserCourseOverviewModel(
    CourseOverviewModel Course,
    UserCourseActivityModel? Activity,
    bool HasExamination
);
