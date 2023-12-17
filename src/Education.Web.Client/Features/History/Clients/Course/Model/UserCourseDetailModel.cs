namespace Education.Web.Client.Features.History.Clients.Course.Model;

public sealed record UserCourseDetailModel(
    CourseModel Course,
    UserCourseActivityModel? Activity,
    bool HasEasyExamination,
    bool HasHardExamination
);
