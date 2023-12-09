using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.Course.Model;

public sealed record ExaminationBuilderModel(
    UserCourseOverviewModel Course,
    ExaminationInformationModel[] Examinations,
    UserInventoryModel[] Inventories
);