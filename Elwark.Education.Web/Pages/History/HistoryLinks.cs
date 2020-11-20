using Elwark.Education.Web.Services.History.Model;

namespace Elwark.Education.Web.Pages.History
{
    public static class HistoryLinks
    {
        public const string Index = "/history";
        public static string Article(string articleId) => $"{Index}/article/{articleId}";
        public static string Period(PeriodType period) => $"{Index}/{period.ToString().ToLower()}";
        public static string Test(string testId) => $"{Index}/test/{testId}";
        public static string Topic(string topicId) => $"{Index}/topic/{topicId}";
    }
}