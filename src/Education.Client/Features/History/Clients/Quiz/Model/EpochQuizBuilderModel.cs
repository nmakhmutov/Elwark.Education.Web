using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record EpochQuizBuilderModel(QuizInformationModel[] Quizzes, UserInventoryModel[] Inventories);
