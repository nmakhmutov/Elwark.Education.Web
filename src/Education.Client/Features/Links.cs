using Education.Client.Gateways.History;

namespace Education.Client.Features;

public static class Links
{
    public const string Root = "/";

    public static class Authentication
    {
        public const string LogOut = "/authentication/logout";

        public static string LogIn(string returnUrl) =>
            $"/authentication/login?returnUrl={returnUrl}";
    }

    public static class Account
    {
        public const string Index = "/account";
    }

    public static class History
    {
        public const string Index = "/history";

        public const string Empires = $"{Index}/empires";
        
        public const string TestBuilder = $"{Index}/tests";

        public const string EventGuesserBuilder = $"{Index}/event-guessers";

        public const string MyProfile = $"{Index}/my/profile";

        public const string MyEasyTests = $"{Index}/my/tests/easy";

        public const string MyHardTests = $"{Index}/my/tests/hard";

        public const string MyMixedTests = $"{Index}/my/tests/mixed";

        public const string MyEventGuessers = $"{Index}/my/event-guessers";

        public const string MyFavorites = $"{Index}/my/favorites";
        
        public const string MyAchievements = $"{Index}/my/achievements";

        public static string MyTopicProgress(string topicId) =>
            $"{Index}/my/topics/{topicId}";

        public static string TopicByEpoch(EpochType epoch) =>
            $"{Index}/{epoch.ToFastString()}";

        public static string TopicById(string topicId) =>
            $"{Index}/topics/{topicId}";

        public static string TestById(string testId) =>
            $"{TestBuilder}/{testId}";

        public static string TestConclusion(string testId) =>
            $"{TestBuilder}/{testId}/conclusion";
    }

    public static class Store
    {
        public const string Index = "/store";

        public const string Checkout = $"{Index}/checkout";
    }
}
