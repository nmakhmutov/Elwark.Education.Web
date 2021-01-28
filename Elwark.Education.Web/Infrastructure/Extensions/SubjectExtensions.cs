using Elwark.Education.Web.Model;
using MudBlazor;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class SubjectExtensions
    {
        public static string GetIcon(this SubjectType type) =>
            type switch
            {
                SubjectType.History => TwoTone.AccountBalanceTwoTone,
                // SubjectType.Physics => Icons.Custom.Radioactive,
                SubjectType.Astronomy => Filled.Flare,
                _ => Filled.Adjust
            };

        public static string GetBackground(this SubjectType type) =>
            type switch
            {
                SubjectType.History => "/images/subjects/history.jpg",
                // SubjectType.Physics => "/images/subjects/physics.jpg",
                SubjectType.Astronomy => "/images/subjects/astronomy.jpg",
                _ => string.Empty
            };
    }
}