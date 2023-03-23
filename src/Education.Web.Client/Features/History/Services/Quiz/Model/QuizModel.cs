using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizModel(QuizOverviewModel Overview, QuizQuestion Question, TestInventoryModel[] Inventory);