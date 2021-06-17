using System;
using Elwark.Education.Web.Gateways.Models.Test;
using MudBlazor;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class ConclusionStatusExtensions
    {
        public static Color GetColor(this ConclusionStatus status) =>
            status switch
            {
                ConclusionStatus.Complete => Color.Success,
                ConclusionStatus.TimeExceeded => Color.Error,
                ConclusionStatus.MistakesExceeded => Color.Warning,
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            };
    }
}
