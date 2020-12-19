using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Pages
{
    public static class Links
    {
        public const string Index = "/";

        public static class Profile
        {
            public const string Index = "/profile";

            public static string Overview(Subject subject) =>
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
        }

        public static class Astronomy
        {
            public const string Index = "/astronomy";
        }
    }
}