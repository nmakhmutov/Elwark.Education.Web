using System;
using MudBlazor;

namespace Education.Client.Gateways.Models.Test
{
    public enum ConclusionStatus
    {
        Complete = 0,
        TimeExceeded = 1,
        MistakesExceeded = 2
    }
    
    internal static class ConclusionStatusExtensions
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
