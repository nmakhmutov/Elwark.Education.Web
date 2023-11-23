using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizInformationModel(DifficultyType Type, string Title, string ImageUrl, bool IsAllowed);
