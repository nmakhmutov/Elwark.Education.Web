using Education.Web.Client.Models.Content;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizOverviewModel(
    string Id,
    DifficultyType Type,
    ArticleTitleModel Article,
    uint Completed,
    uint Questions,
    DateTime ExpiredAt
);
