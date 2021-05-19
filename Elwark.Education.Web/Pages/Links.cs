using Elwark.Education.Web.Gateways.Models.History;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Pages
{
    public static class Links
    {
        public const string Root = "/";

        public static class Authentication
        {
            public static string LogIn(string returnUrl) =>
                $"authentication/login?returnUrl={returnUrl}";

            public const string LogOut = "authentication/logout";
        }
        
        public static class Profile
        {
            public const string Index = "/profile";

            public static string Overview(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}";

            public static string Statistics(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}/statistics";
            
            public static string Favorites(SubjectType type) =>
                $"{Index}/{type.ToString().ToLowerInvariant()}/favorites";
        }

        public static class History
        {
            public const string Index = "/history";

            public static string Epoch(EpochType period) =>
                $"{Index}/{period.ToString().ToLowerInvariant()}";

            public static string Topics() =>
                $"{Index}/topics";
            
            public static string Topics(string topicId) =>
                $"{Topics()}/{topicId}";

            public static string Test(string testId) =>
                $"{Index}/test/{testId}";
            
            public static string Conclusion(string testId) =>
                $"{Index}/test/{testId}/conclusion";
        }

        public static class Subjects
        {
            public static string Index(SubjectType type) =>
                type switch
                {
                    SubjectType.History => History.Index,
                    _ => string.Empty
                };

            public static string Topic(SubjectType type, string topicId) =>
                type switch
                {
                    SubjectType.History => History.Topics(topicId),
                    _ => string.Empty
                };

            public static string Test(SubjectType type, string testId) =>
                type switch
                {
                    SubjectType.History => History.Test(testId),
                    _ => string.Empty
                };
        }

        public static class Shop
        {
            public const string Index = "/shop";
        }
    }
}
