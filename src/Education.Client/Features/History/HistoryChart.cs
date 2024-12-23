namespace Education.Client.Features.History;

public static class HistoryChart
{
    public static class Quiz
    {
        public static class Difficulty
        {
            public static string Easy { get; } = "#32BAFF";

            public static string Hard { get; } = "#0099E6";

            public static string Expert { get; } = "#006FB3";
        }

        public static class Completeness
        {
            public static string Successful { get; } = "#00A76F";

            public static string Failed { get; } = "#FF5630";

            public static string TimeExceeded { get; } = "#FFAB00";

            public static string MistakesLimitExceeded { get; } = "#00B8D9";
        }

        public static class Score
        {
            public static string Questions { get; } = "#00A76F";

            public static string SpeedBonus { get; } = "#FFAB00";

            public static string NoMistakesBonus { get; } = "#00B8D9";
        }

        public static class Question
        {
            public static string Correct { get; } = "#00A76F";

            public static string Incorrect { get; } = "#FF5630";

            public static string Answered { get; } = "#FFAB00";

            public static string NotAnswered { get; } = "#00B8D9";
        }

        public static class TimeSpent
        {
            public static string Minimum { get; } = "#00A76F";

            public static string Average { get; } = "#FFAB00";

            public static string Maximum { get; } = "#00B8D9";
        }
    }

    public static class Examination
    {
        public static class Difficulty
        {
            public static string Easy { get; } = "#00ADAD";

            public static string Hard { get; } = "#01837F";
        }

        public static class Completeness
        {
            public static string Successful { get; } = "#00A76F";

            public static string Failed { get; } = "#FF5630";

            public static string TimeExceeded { get; } = "#FFAB00";
        }

        public static class Score
        {
            public static string Questions { get; } = "#00A76F";

            public static string SpeedBonus { get; } = "#FFAB00";

            public static string NoMistakesBonus { get; } = "#00B8D9";
        }

        public static class Question
        {
            public static string Correct { get; } = "#00A76F";

            public static string Incorrect { get; } = "#FF5630";

            public static string Answered { get; } = "#FFAB00";

            public static string NotAnswered { get; } = "#00B8D9";
        }

        public static class TimeSpent
        {
            public static string Minimum { get; } = "#00A76F";

            public static string Average { get; } = "#FFAB00";

            public static string Maximum { get; } = "#00B8D9";
        }
    }

    public static class DateGuesser
    {
        public static string Tests { get; } = "#00A76F";

        public static class Size
        {
            public static string Small { get; } = "#B992FE";

            public static string Medium { get; } = "#AB7EFD";

            public static string Large { get; } = "#9A69FC";
        }

        public static class Score
        {
            public static string Points { get; } = "#00A76F";

            public static string X2Points { get; } = "#FFAB00";
        }

        public static class Question
        {
            public static string Correct { get; } = "#00A76F";

            public static string Incorrect { get; } = "#FF5630";
        }
    }
}
