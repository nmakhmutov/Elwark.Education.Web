using Elwark.Education.Web.Services.History.Model;

namespace Elwark.Education.Web.Pages
{
    public static class Links
    {
        public const string Index = "/";

        public static class History
        {
            public const string Index = "/history";

            public static string Period(PeriodType period) => $"{Index}/{period.ToString().ToLower()}";

            public static string Topic(string topicId) => $"{Index}/topic/{topicId}";

            public static string Article(string articleId) => $"{Index}/article/{articleId}";

            public static string Test(string testId) => $"{Index}/test/{testId}";
        }
    }
}