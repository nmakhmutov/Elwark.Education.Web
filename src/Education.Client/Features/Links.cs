using Education.Client.Gateways.History;

namespace Education.Client.Features;

public static class Links
{
    public static class Root
    {
        public const string Index = "/";
    }

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

        public static class Content
        {
            public const string Empires = $"{Index}/empires";

            public static string Epoch(EpochType epoch) =>
                $"{Index}/epochs/{epoch.ToFastString()}";

            public static string Topic(string topicId) =>
                $"{Index}/topics/{topicId}";
        }

        public static class TopicTest
        {
            public const string Builder = $"{Index}/tests";

            public static string Test(string testId) =>
                $"{Builder}/{testId}";

            public static string Conclusion(string testId) =>
                $"{Builder}/{testId}/conclusion";
        }

        public static class EventGuesser
        {
            public const string Builder = $"{Index}/event-guessers";

            public const string Test = $"{Index}/event-guessers/test";

            public const string Conclusion = $"{Index}/event-guessers/conclusion";
        }

        public static class User
        {
            public const string MyProfile = $"{Index}/my/profile";

            public const string MyEasyTests = $"{Index}/my/tests/easy";

            public const string MyHardTests = $"{Index}/my/tests/hard";

            public const string MyMixedTests = $"{Index}/my/tests/mixed";

            public const string MyEventGuessers = $"{Index}/my/event-guessers";

            public const string MyAchievements = $"{Index}/my/achievements";

            public const string MyActivities = $"{Index}/my/activities";

            public const string MyFavorites = $"{Index}/my/favorites";
            
            public static string MyTopic(string topicId) =>
                $"{Index}/my/topics/{topicId}";
        }
    }

    public static class Store
    {
        public const string Index = "/store";

        public const string Checkout = $"{Index}/checkout";
    }
}
