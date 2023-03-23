using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizAnswerModel(
    QuizOverviewModel Overview,
    AnswerResult Answer,
    QuizQuestion? NextQuestion,
    TestInventoryModel[] Inventory
);
