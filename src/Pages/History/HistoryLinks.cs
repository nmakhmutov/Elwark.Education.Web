using Education.Web.Gateways.History;

namespace Education.Web.Pages.History;

public static class HistoryLinks
{
    public const string Root = "/history";

    public static class Content
    {
        public const string Empires = $"{Root}/empires";

        public static string Epoch(EpochType epoch) =>
            $"{Root}/epochs/{epoch.ToFastString().ToLowerInvariant()}";

        public static string Topic(string topicId) =>
            $"{Root}/topics/{topicId}";
    }

    public static class TopicTest
    {
        public static string Index(string? topicId = null) =>
            string.IsNullOrEmpty(topicId)
                ? $"{Root}/tests"
                : $"{Root}/tests?topic={topicId}";

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
        public const string Index = $"{Root}/leaderboard";
    }

    public static class User
    {
        public const string MyProfile = $"{Root}/my/profile";

        public const string MyEasyTests = $"{Root}/my/tests/easy";

        public const string MyHardTests = $"{Root}/my/tests/hard";

        public const string MyMixedTests = $"{Root}/my/tests/mixed";

        public const string MyEventGuessers = $"{Root}/my/event-guessers";

        public const string MyAchievements = $"{Root}/my/achievements";

        public const string MyInventories = $"{Root}/my/inventories";

        public const string MyActivities = $"{Root}/my/activities";

        public const string MyFavorites = $"{Root}/my/favorites";

        public static string MyTopic(string topicId) =>
            $"{Root}/my/topics/{topicId}";
    }
}
