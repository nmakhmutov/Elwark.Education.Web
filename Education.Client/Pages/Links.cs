using Education.Client.Gateways.History.Epoch;

namespace Education.Client.Pages
{
    public static class Links
    {
        public const string Root = "/";

        public static class Authentication
        {
            public const string LogOut = "authentication/logout";

            public static string LogIn(string returnUrl) =>
                $"authentication/login?returnUrl={returnUrl}";
        }

        public static class Profile
        {
            public const string Index = "/profile";

            public static class History
            {
                public const string Overview = Index + "/history";

                public const string Statistics = Overview + "/statistics";

                public const string EasyTestStatistics = Statistics + "/easy-tests";

                public const string HardTestStatistics = Statistics + "/hard-tests";

                public const string MixedTestStatistics = Statistics + "/mixed-tests";

                public const string Favorites = Overview + "/favorites";

                public static string TopicStatistics(string topicId) => $"{Statistics}/topic/{topicId}";
            }
        }

        public static class Subject
        {
            public static class History
            {
                public const string Index = "/history";

                private const string Topics = Index + "/topics";

                public static string Epoch(EpochType period) =>
                    $"{Index}/{period.ToString().ToLowerInvariant()}";

                public static string Topic(string topicId) =>
                    $"{Topics}/{topicId}";

                public static string Test(string testId) =>
                    $"{Index}/test/{testId}";

                public static string Conclusion(string testId) =>
                    $"{Index}/test/{testId}/conclusion";
            }
        }

        public static class Shop
        {
            public const string Index = "/shop";
        }
    }
}
