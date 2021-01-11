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

            public static string Statistics(SubjectType subjectType) =>
                $"{Index}/{subjectType.ToString().ToLowerInvariant()}";

            public static string Tests(SubjectType subjectType) =>
                $"{Index}/{subjectType.ToString().ToLowerInvariant()}/tests";

            public static string TestDetail(SubjectType subjectType, string testId) =>
                $"{Tests(subjectType)}/{testId}";
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

        public static class Physics
        {
            public const string Index = "/physics";

            public static string Topic(string topicId) =>
                $"{Index}/topic/{topicId}";

            public static string Article(string articleId) =>
                $"{Index}/article/{articleId}";
        }

        public static class Astronomy
        {
            public const string Index = "/astronomy";

            public static string Topic(string topicId) =>
                $"{Index}/topic/{topicId}";

            public static string Article(string articleId) =>
                $"{Index}/article/{articleId}";
        }

        public static class Subjects
        {
            public static string Index(SubjectType subjectType) =>
                subjectType switch
                {
                    SubjectType.History => History.Index,
                    SubjectType.Physics => Physics.Index,
                    SubjectType.Astronomy => Astronomy.Index,
                    _ => string.Empty
                };

            public static string Topic(SubjectType subjectType, string topicId) =>
                subjectType switch
                {
                    SubjectType.History => History.Topic(topicId),
                    SubjectType.Physics => Physics.Topic(topicId),
                    SubjectType.Astronomy => Astronomy.Topic(topicId),
                    _ => string.Empty
                };

            public static string Article(SubjectType subjectType, string articleId) =>
                subjectType switch
                {
                    SubjectType.History => History.Article(articleId),
                    SubjectType.Physics => Physics.Article(articleId),
                    SubjectType.Astronomy => Astronomy.Article(articleId),
                    _ => string.Empty
                };
        }
    }
}