using MudBlazor;

namespace Elwark.Education.Web.Model
{
    public sealed record LearningProgress(int Count, int Passed)
    {
        public int Current => Passed * 100 / Count;

        public string Color => Current switch
        {
            0 or < 10 => Colors.Indigo.Darken4,
            10 or < 20 => Colors.Indigo.Darken3,
            20 or < 30 => Colors.Indigo.Darken2,
            30 or < 40 => Colors.Blue.Darken3,
            40 or < 50 => Colors.Blue.Darken2,
            50 or < 60 => Colors.Blue.Darken1,
            60 or < 70 => Colors.Teal.Darken1,
            70 or < 80 => Colors.Teal.Lighten1,
            80 or < 90 => Colors.Teal.Lighten2,
            90 or < 99 => Colors.Green.Lighten1,
            _ => Colors.Green.Darken1
        };
    }
}