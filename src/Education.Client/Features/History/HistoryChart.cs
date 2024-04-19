using MudBlazor;

namespace Education.Client.Features.History;

public static class HistoryChart
{
    public static class Quiz
    {
        public static class Difficulty
        {
            public static string Easy { get; } = Colors.Blue.Lighten3;

            public static string Hard { get; } = Colors.Blue.Lighten1;
        }

        public static class Completeness
        {
            public static string Successful { get; } = Colors.Green.Accent4;

            public static string Failed { get; } = Colors.Red.Default;

            public static string TimeExceeded { get; } = Colors.Blue.Default;

            public static string MistakesExceeded { get; } = Colors.DeepPurple.Default;
        }

        public static class Score
        {
            public static string Questions { get; } = Colors.Green.Accent4;

            public static string SpeedBonus { get; } = Colors.Blue.Default;

            public static string NoMistakesBonus { get; } = Colors.DeepPurple.Default;
        }

        public static class Question
        {
            public static string Correct { get; } = Colors.Green.Accent4;

            public static string Incorrect { get; } = Colors.Red.Default;

            public static string Answered { get; } = Colors.Blue.Default;

            public static string NotAnswered { get; } = Colors.DeepPurple.Default;
        }

        public static class TimeSpent
        {
            public static string Minimum { get; } = Colors.Green.Accent4;

            public static string Average { get; } = Colors.Blue.Default;

            public static string Maximum { get; } = Colors.DeepPurple.Default;
        }
    }

    public static class Examination
    {
        public static class Difficulty
        {
            public static string Easy { get; } = Colors.Blue.Lighten3;

            public static string Hard { get; } = Colors.Blue.Lighten1;
        }

        public static class Completeness
        {
            public static string Successful { get; } = Colors.Green.Accent4;

            public static string Failed { get; } = Colors.Red.Default;

            public static string TimeExceeded { get; } = Colors.Blue.Default;
        }

        public static class Score
        {
            public static string Questions { get; } = Colors.Green.Accent4;

            public static string SpeedBonus { get; } = Colors.Blue.Default;

            public static string NoMistakesBonus { get; } = Colors.DeepPurple.Default;
        }

        public static class Question
        {
            public static string Correct { get; } = Colors.Green.Accent4;

            public static string Incorrect { get; } = Colors.Red.Default;

            public static string Answered { get; } = Colors.Blue.Default;

            public static string NotAnswered { get; } = Colors.DeepPurple.Default;
        }

        public static class TimeSpent
        {
            public static string Minimum { get; } = Colors.Green.Accent4;

            public static string Average { get; } = Colors.Blue.Default;

            public static string Maximum { get; } = Colors.DeepPurple.Default;
        }
    }

    public static class DateGuesser
    {
        public static class Size
        {
            public static string Small { get; } = Colors.Orange.Lighten3;

            public static string Medium { get; } = Colors.Orange.Lighten1;

            public static string Large { get; } = Colors.Orange.Darken2;
        }

        public static class Score
        {
            public static string Points { get; } = Colors.Blue.Default;

            public static string X2Points { get; } = Colors.DeepPurple.Default;
        }

        public static class Question
        {
            public static string Correct { get; } = Colors.Green.Accent4;

            public static string Incorrect { get; } = Colors.Red.Default;
        }
    }
}