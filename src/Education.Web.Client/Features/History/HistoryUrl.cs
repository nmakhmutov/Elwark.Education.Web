using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Article.Request;

namespace Education.Web.Client.Features.History;

public static class HistoryUrl
{
    public const string Root = "/history";

    public static string Search(string? q = null) =>
        string.IsNullOrEmpty(q) ? $"{Root}/search" : $"{Root}/search?q={q}";

    public static class Content
    {
        public const string Empires = $"{Root}/empires";
        public const string Courses = $"{Root}/courses";

        public static string Articles() =>
            $"{Root}/articles";

        public static string Articles(EpochType epoch) =>
            $"{Root}/articles?epoch={epoch.ToFastString().ToLowerInvariant()}";

        public static string Articles(GetArticlesRequest.SortType sort) =>
            $"{Root}/articles?sort={sort.ToString().ToLowerInvariant()}";

        public static string Article(string articleId) =>
            $"{Root}/article/{articleId}";

        public static string Course(string courseId) =>
            $"{Root}/course/{courseId}";
    }

    public static class ArticleQuiz
    {
        public static string Index() =>
            $"{Root}/quizzes";

        public static string Index(string articleId) =>
            $"{Root}/quizzes?article={articleId}";

        public static string Test(string testId) =>
            $"{Root}/quizzes/{testId}";

        public static string Conclusion(string testId) =>
            $"{Root}/quizzes/{testId}/conclusion";
    }

    public static class EventGuesser
    {
        public const string Index = $"{Root}/event-guessers";

        public static string Test(string testId) =>
            $"{Root}/event-guessers/{testId}";

        public static string Conclusion(string testId) =>
            $"{Root}/event-guessers/{testId}/conclusion";
    }

    public static class Leaderboard
    {
        public const string Global = $"{Root}/leaderboards/global";

        public const string Monthly = $"{Root}/leaderboards/monthly";
    }

    public static class Store
    {
        public const string Index = $"{Root}/store";
    }

    public static class User
    {
        private const string My = $"{Root}/my";

        public const string MyProfile = $"{My}/profile";

        public const string MyBackpack = $"{My}/backpack";

        public const string MyEasyQuizzes = $"{My}/quizzes/easy";

        public const string MyHardQuizzes = $"{My}/quizzes/hard";

        public const string MySmallEventGuessers = $"{My}/event-guessers/small";

        public const string MyMediumEventGuessers = $"{My}/event-guessers/medium";

        public const string MyLargeEventGuessers = $"{My}/event-guessers/large";

        public const string MySilver = $"{My}/accounting/silver";

        public const string MyAchievements = $"{My}/achievements";

        public const string MyQuests = $"{My}/quests";

        public const string MyStatistics = $"{My}/statistics";

        public const string MyBookmarks = $"{My}/bookmarks";

        public static string MyArticle(string articleId) =>
            $"{My}/article/{articleId}";

        public static string MyCourse(string courseId) =>
            $"{My}/course/{courseId}";
    }
}
