using System;
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

            public static string Statistics(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}";

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

        public static class Physics
        {
            public const string Index = "/physics";

            public static string Topic(string topicId) =>
                $"{Index}/topic/{topicId}";

            public static string Article(string articleId) =>
                $"{Index}/article/{articleId}";
            
            public static string Test(string testId) =>
                $"{Index}/test/{testId}";
            
        }

        public static class Astronomy
        {
            public const string Index = "/astronomy";

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
                    SubjectType.Physics => Physics.Index,
                    SubjectType.Astronomy => Astronomy.Index,
                    _ => string.Empty
                };

            public static string Topic(SubjectType type, string topicId) =>
                type switch
                {
                    SubjectType.History => History.Topic(topicId),
                    SubjectType.Physics => Physics.Topic(topicId),
                    SubjectType.Astronomy => Astronomy.Topic(topicId),
                    _ => string.Empty
                };

            public static string Article(SubjectType type, string articleId) =>
                type switch
                {
                    SubjectType.History => History.Article(articleId),
                    SubjectType.Physics => Physics.Article(articleId),
                    SubjectType.Astronomy => Astronomy.Article(articleId),
                    _ => string.Empty
                };

            public static string Test(SubjectType type, string testId) =>
                type switch
                {
                    SubjectType.History => History.Test(testId),
                    SubjectType.Physics => Physics.Test(testId),
                    SubjectType.Astronomy => Astronomy.Test(testId),
                    _ => string.Empty
                };
        }
        
        public static class Shop
        {
            public const string Index = "/shop";
        }
    }
}