using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Features.History.Clients.Course.Request;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History;

public static class HistoryUrl
{
    public const string Root = "/history";

    public static string Search(string? q = null) =>
        string.IsNullOrEmpty(q) ? $"{Root}/search" : $"{Root}/search?q={q}";

    public static class Content
    {
        public const string Random = $"{Root}/random";

        public const string Empires = $"{Root}/empires";

        public const string Timeline = $"{Root}/timeline";

        public static string Articles() =>
            $"{Root}/articles";

        public static string Articles(EpochType epoch) =>
            Articles(GetArticlesRequest.SortType.Trending, epoch);

        public static string Articles(GetArticlesRequest.SortType sort, EpochType epoch = EpochType.None)
        {
            var dictionary = new Dictionary<string, string?>(2)
            {
                ["category"] = sort.ToString()
            };

            if (epoch > EpochType.None)
                dictionary.Add("epoch", epoch.ToFastString());

            var query = QueryString.Create(dictionary).ToString();

            return $"{Root}/articles{query}";
        }

        public static string Article(string articleId) =>
            $"{Root}/article/{articleId}";

        public static string QuizBuilder(string articleId) =>
            $"{Root}/article/{articleId}/quiz";

        public static string Courses() =>
            $"{Root}/courses";

        public static string Courses(GetCourseRequest.SortType sort) =>
            $"{Root}/courses?category={sort.ToString().ToLowerInvariant()}";

        public static string Course(string courseId) =>
            $"{Root}/course/{courseId}";

        public static string ExaminationBuilder(string courseId) =>
            $"{Root}/course/{courseId}/examination";
    }

    public static class Flow
    {
        public static string Index() =>
            $"{Root}/flow";
    }

    public static class Quiz
    {
        public static string Index() =>
            $"{Root}/quizzes";

        public static string Test(string testId) =>
            $"{Root}/quizzes/{testId}";

        public static string Conclusion(string testId) =>
            $"{Root}/quizzes/{testId}/conclusion";
    }

    public static class Examination
    {
        public static string Test(string testId) =>
            $"{Root}/examinations/{testId}";

        public static string Conclusion(string testId) =>
            $"{Root}/examinations/{testId}/conclusion";
    }

    public static class DateGuesser
    {
        public const string Index = $"{Root}/date-guessers";

        public static string Test(string testId) =>
            $"{Root}/date-guessers/{testId}";

        public static string Conclusion(string testId) =>
            $"{Root}/date-guessers/{testId}/conclusion";
    }

    public static class Leaderboard
    {
        public const string AllTime = $"{Root}/leaderboards/all-time";

        public static string Monthly() =>
            $"{Root}/leaderboards/monthly";

        public static string Monthly(DateOnly month) =>
            $"{Root}/leaderboards/monthly?month={month.ToString("O")}";

        public static string Monthly(string month) =>
            $"{Root}/leaderboards/monthly?month={month}";
    }

    public static class Store
    {
        public static string Index() =>
            $"{Root}/store";

        public static string Index(CategoryType category) =>
            category == CategoryType.None
                ? $"{Root}/store"
                : $"{Root}/store?category={category.ToFastString().ToLower()}";

        public static string Index(CategoryType category, uint id) =>
            category == CategoryType.None
                ? $"{Root}/store?id={id}"
                : $"{Root}/store?category={category.ToFastString().ToLower()}&id={id}";
    }

    public static class User
    {
        private const string My = $"{Root}/my";

        public const string MyDashboard = $"{My}/dashboard";

        public const string MyBackpack = $"{My}/backpack";

        public const string MyBookmarks = $"{My}/bookmarks";

        public const string MyFinance = $"{My}/finance";

        public const string MyQuizzes = $"{My}/quizzes";

        public const string MyEasyQuizzes = $"{My}/quizzes/easy";

        public const string MyHardQuizzes = $"{My}/quizzes/hard";

        public const string MyExpertQuizzes = $"{My}/quizzes/expert";

        public const string MyExaminations = $"{My}/examinations";

        public const string MyEasyExaminations = $"{My}/examinations/easy";

        public const string MyHardExaminations = $"{My}/examinations/hard";

        public const string MyDateGuessers = $"{My}/date-guessers";

        public const string MySmallDateGuessers = $"{My}/date-guessers/small";

        public const string MyMediumDateGuessers = $"{My}/date-guessers/medium";

        public const string MyLargeDateGuessers = $"{My}/date-guessers/large";

        public const string MyAchievements = $"{My}/achievements";

        public static string MyAssignments() =>
            $"{My}/assignments";

        public static string MyAssignments(string tab) =>
            $"{My}/assignments?tab={tab}";

        public static string MyArticle() =>
            $"{My}/articles";

        public static string MyArticle(string articleId) =>
            $"{My}/article/{articleId}";

        public static string MyCourse() =>
            $"{My}/courses";

        public static string MyCourse(string courseId) =>
            $"{My}/course/{courseId}";
    }
}
