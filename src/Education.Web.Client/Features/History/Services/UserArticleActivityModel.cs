using Education.Web.Client.Features.History.Services.User.Model.Quiz;

namespace Education.Web.Client.Features.History.Services;

public sealed record UserArticleActivityModel(
    NumberOfQuizzesModel NumberOfEasyQuiz,
    NumberOfQuizzesModel NumberOfHardQuiz,
    bool IsBookmarked,
    bool? IsLiked
)
{
    public bool IsPassedAnyQuizzes =>
        NumberOfEasyQuiz.Total + NumberOfHardQuiz.Total > 0;
}
