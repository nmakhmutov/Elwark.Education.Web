using System;
using Elwark.Education.Web.Model;
using MudBlazor;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public sealed record SubjectStatic(string Icon, string Image, string Gradient);

    public static class SubjectExtensions
    {
        public static SubjectStatic GetStatic(this SubjectType type) =>
            type switch
            {
                SubjectType.History =>
                    new SubjectStatic(
                        Icons.Outlined.AccountBalance,
                        "/images/subjects/history.jpg",
                        "linear-gradient(140deg, rgba(226, 110, 67, 1) 0%, rgba(248, 206, 14, 1) 100%)"
                    ),

                SubjectType.Astronomy =>
                    new SubjectStatic(
                        Icons.Filled.Flare,
                        "/images/subjects/astronomy.jpg",
                        "linear-gradient(140deg, rgba(53, 58, 95, 1) 0%, rgba(158, 186, 243, 1) 100%)"
                    ),

                // SubjectType.Physics =>
                //     new SubjectStatic(
                //         Icons.Custom.Uncategorized.Radioactive,
                //         "/images/subjects/physics.jpg",
                //         "linear-gradient(140deg, rgba(28, 46, 76, 1) 0%, rgba(108, 208, 255, 1) 100%)"
                //         ),

                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
    }
}
