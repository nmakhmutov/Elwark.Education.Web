using Elwark.Education.Web.Model;
using MudBlazor;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class SubjectExtensions
    {
        public static string GetIcon(this SubjectType subjectType) =>
            subjectType switch
            {
                SubjectType.History => TwoTone.AccountBalanceTwoTone,
                SubjectType.Physics => Icons.Custom.Radioactive,
                SubjectType.Astronomy => Filled.Flare,
                _ => Filled.Adjust
            };
    }
}