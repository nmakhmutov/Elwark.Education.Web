using Elwark.Education.Web.Model;
using MudBlazor;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class SubjectExtensions
    {
        public static string GetIcon(this Subject subject) =>
            subject switch
            {
                Subject.History => TwoTone.AccountBalanceTwoTone,
                Subject.Physics => Icons.Custom.Radioactive,
                Subject.Astronomy => Filled.Flare,
                _ => Filled.Adjust
            };
    }
}