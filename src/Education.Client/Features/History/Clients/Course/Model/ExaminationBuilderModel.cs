using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Course.Model;

public sealed record ExaminationBuilderModel(
    CourseOverviewModel Course,
    UserCourseActivityModel? Activity,
    ExaminationInformationModel[] Examinations,
    UserInventoryModel[] Inventories
);
