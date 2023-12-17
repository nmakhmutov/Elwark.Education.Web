using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Clients.Course.Model;

public sealed record ExaminationBuilderModel(
    CourseOverviewModel Course,
    UserCourseActivityModel? Activity,
    ExaminationInformationModel[] Examinations,
    UserInventoryModel[] Inventories
);
