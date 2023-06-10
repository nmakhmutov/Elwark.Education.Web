using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record UsedInventoryModel(
    QuizOverviewModel Overview,
    QuizQuestion? Question,
    TestInventoryModel[] Inventory
);