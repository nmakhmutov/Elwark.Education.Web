using Education.Web.Client.Features.History.Services;

namespace Education.Web.Client.Features.History;

public static class HistoryUrl
{
    public const string Root = "/history";

    public static class Content
    {
        public const string Empires = $"{Root}/empires";

        public static string Epoch(EpochType epoch) =>
            $"{Root}/epochs/{epoch.ToFastString().ToLowerInvariant()}";

        public static string Article(string articleId) =>
            $"{Root}/articles/{articleId}";
    }

    public static class ArticleTest
    {
        public static string Index(string? articleId = null) =>
            string.IsNullOrEmpty(articleId)
                ? $"{Root}/tests"
                : $"{Root}/tests?article={articleId}";

        public static string Test(string testId) =>
            $"{Root}/tests/{testId}";

        public static string Conclusion(string testId) =>
            $"{Root}/tests/{testId}/conclusion";
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
        public const string MyProfile = $"{Root}/my/profile";

        public const string MyInventories = $"{Root}/my/inventories";

        public const string MyEasyTests = $"{Root}/my/tests/easy";

        public const string MyHardTests = $"{Root}/my/tests/hard";

        public const string MyMixedTests = $"{Root}/my/tests/mixed";

        public const string MySmallEventGuessers = $"{Root}/my/event-guessers/small";

        public const string MyMediumEventGuessers = $"{Root}/my/event-guessers/medium";

        public const string MyLargeEventGuessers = $"{Root}/my/event-guessers/large";

        public const string MySilver = $"{Root}/my/monies/silver";

        public const string MyAchievements = $"{Root}/my/achievements";

        public const string MyQuests = $"{Root}/my/quests";

        public const string MyStatistics = $"{Root}/my/statistics";

        public const string MyBookmarks = $"{Root}/my/bookmarks";

        public static string MyArticles(string articleId) =>
            $"{Root}/my/articles/{articleId}";
    }
}
