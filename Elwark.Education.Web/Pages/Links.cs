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

            public static string Statistics(Subject subject) =>
                $"{Index}/{subject.ToString().ToLowerInvariant()}";

            public static string Tests(Subject subject) =>
                $"{Index}/{subject.ToString().ToLowerInvariant()}/tests";

            public static string TestDetail(Subject subject, string testId) =>
                $"{Tests(subject)}/{testId}";
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
            public static string Index(Subject subject) =>
                subject switch
                {
                    Subject.History => History.Index,
                    Subject.Physics => Physics.Index,
                    Subject.Astronomy => Astronomy.Index,
                    _ => string.Empty
                };

            public static string Topic(Subject subject, string topicId) =>
                subject switch
                {
                    Subject.History => History.Topic(topicId),
                    Subject.Physics => Physics.Topic(topicId),
                    Subject.Astronomy => Astronomy.Topic(topicId),
                    _ => string.Empty
                };

            public static string Article(Subject subject, string articleId) =>
                subject switch
                {
                    Subject.History => History.Article(articleId),
                    Subject.Physics => Physics.Article(articleId),
                    Subject.Astronomy => Astronomy.Article(articleId),
                    _ => string.Empty
                };
        }
    }
}