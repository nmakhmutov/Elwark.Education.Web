using MudBlazor;

namespace Elwark.Education.Web.Services
{
    public sealed record LearningProgress(int Count, int Passed)
    {
        public int Current => Passed * 100 / Count;

        public Color Color => Current switch
        {
            0 or < 20 => Color.Default,
            20 or < 40 => Color.Error,
            40 or < 60 => Color.Warning,
            60 or < 80 => Color.Success,
            _ => Color.Primary
        };
    }
}