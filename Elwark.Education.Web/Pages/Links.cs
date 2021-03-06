using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Pages
{
    public static class Links
    {
        public const string Root = "/";

        public static class Profile
        {
            public const string Index = "/profile";

            public static string Overview(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}";

            public static string Statistics(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}/statistics";

            public static string Tests(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}/tests";

            public static string TestDetail(SubjectType type, string testId) =>
                $"{Tests(type)}/{testId}";
        }

        public static class History
        {
            public const string Index = "/history";

            public static string Period(HistoryPeriodType period) =>
                $"{Index}/{period.ToString().ToLowerInvariant()}";

            public static string Topic(string topicId) =>
                $"{Index}/topic/{topicId}";

            public static string Article(string articleId) =>
                $"{Index}/article/{articleId}";

            public static string Test(string testId) =>
                $"{Index}/test/{testId}";
        }

        public static class Subjects
        {
            public static string Index(SubjectType type) =>
                type switch
                {
                    SubjectType.History => History.Index,
                    SubjectType.Astronomy => "",
                    _ => string.Empty
                };

            public static string Topic(SubjectType type, string topicId) =>
                type switch
                {
                    SubjectType.History => History.Topic(topicId),
                    SubjectType.Astronomy => "",
                    _ => string.Empty
                };

            public static string Article(SubjectType type, string articleId) =>
                type switch
                {
                    SubjectType.History => History.Article(articleId),
                    SubjectType.Astronomy => "",
                    _ => string.Empty
                };

            public static string Test(SubjectType type, string testId) =>
                type switch
                {
                    SubjectType.History => History.Test(testId),
                    SubjectType.Astronomy => "",
                    _ => string.Empty
                };
        }

        public static class Shop
        {
            public const string Index = "/shop";
        }
    }
}