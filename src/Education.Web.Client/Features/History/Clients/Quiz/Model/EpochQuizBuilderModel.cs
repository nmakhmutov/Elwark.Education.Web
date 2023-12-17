using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Clients.Quiz.Model;

public sealed record EpochQuizBuilderModel(QuizInformationModel[] Quizzes, UserInventoryModel[] Inventories);
