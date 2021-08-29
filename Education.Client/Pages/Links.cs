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
            public const string DateGuesser = $"{Index}/date-guesser";
            
            public static class Topic
            {
                public static string ByEpoch(EpochType epoch) =>
                    $"{Index}/{epoch.ToFastString()}";

                public static string ById(string topicId) =>
                    $"{Index}/topics/{topicId}";
            }

            public static class Test
            {
                public const string Builder = $"{Index}/tests";

                public static string ById(string testId) =>
                    $"{Builder}/{testId}";

                public static string Conclusion(string testId) =>
                    $"{Builder}/{testId}/conclusion";
            }
            
            public static class Profile
            {
                public const string Me = Index + "/profile/me";

                public const string EasyTestStatistics = Me + "/statistics/easy-tests";

                public const string HardTestStatistics = Me + "/statistics/hard-tests";

                public const string MixedTestStatistics = Me + "/statistics/mixed-tests";

                public const string Favorites = Me + "/favorites";

                public static string TopicStatistics(string topicId) => $"{Me}/statistics/topic/{topicId}";
            }
        }

        public static class Shop
        {
            public const string Index = "/shop";
        }
    }
}
