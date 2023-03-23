using Education.Web.Client.Models.Content;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizOverviewModel(
    string Id,
    QuizType Type,
    ArticleTitleModel Article,
    uint Completed,
    uint Questions,
    DateTime ExpiredAt
);
