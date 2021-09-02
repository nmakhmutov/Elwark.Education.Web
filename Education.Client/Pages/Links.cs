using Education.Client.Gateways.History;

namespace Education.Client.Pages
{
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

            public const string TestBuilder = $"{Index}/tests";

            public const string EventGuesserBuilder = $"{Index}/event-guesser";

            public const string ProfileMe = $"{Index}/profile/me";

            public const string ProfileEasyTest = $"{ProfileMe}/tests/easy";

            public const string ProfileHardTest = $"{ProfileMe}/tests/hard";

            public const string ProfileMixedTest = $"{ProfileMe}/tests/mixed";

            public const string ProfileEventGuesser = $"{ProfileMe}/event-guesser";

            public const string ProfileFavorites = $"{ProfileMe}/favorites";

            public static string TopicByEpoch(EpochType epoch) =>
                $"{Index}/{epoch.ToFastString()}";

            public static string TopicById(string topicId) =>
                $"{Index}/topics/{topicId}";

            public static string TestById(string testId) =>
                $"{TestBuilder}/{testId}";

            public static string TestConclusion(string testId) =>
                $"{TestBuilder}/{testId}/conclusion";

            public static string ProfileTopic(string topicId) => $"{ProfileMe}/topics/{topicId}";
        }

        public static class Shop
        {
            public const string Index = "/shop";
        }
    }
}
