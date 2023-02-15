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
        private const string My = $"{Root}/my";

        public const string MyProfile = $"{My}/profile";

        public const string MyBackpack = $"{My}/backpack";

        public const string MyEasyTests = $"{My}/tests/easy";

        public const string MyHardTests = $"{My}/tests/hard";

        public const string MyMixedTests = $"{My}/tests/mixed";

        public const string MySmallEventGuessers = $"{My}/event-guessers/small";

        public const string MyMediumEventGuessers = $"{My}/event-guessers/medium";

        public const string MyLargeEventGuessers = $"{My}/event-guessers/large";

        public const string MySilver = $"{My}/monies/silver";

        public const string MyAchievements = $"{My}/achievements";

        public const string MyQuests = $"{My}/quests";

        public const string MyStatistics = $"{My}/statistics";

        public const string MyBookmarks = $"{My}/bookmarks";

        public static string MyArticles(string articleId) =>
            $"{My}/articles/{articleId}";
    }
}
