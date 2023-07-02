using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizModel(QuizOverviewModel Overview, Question Question, TestInventoryModel[] Inventory);
