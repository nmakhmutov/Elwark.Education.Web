using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Course.Model;

public sealed record UserCourseDetailModel(
    CourseModel Course,
    UserCourseActivityModel? Activity,
    DifficultyType[] Difficulties
);
