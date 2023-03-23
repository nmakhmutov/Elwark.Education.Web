using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizInformationModel(QuizType Type, string Title, string IconUrl, bool IsAllowed);
