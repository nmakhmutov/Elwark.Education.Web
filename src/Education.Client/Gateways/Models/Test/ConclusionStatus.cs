using System;
using MudBlazor;

namespace Education.Client.Gateways.Models.Test;

public enum ConclusionStatus
{
    Success = 0,
    Fail = 1,
    TimeExceeded = 2,
    MistakesExceeded = 3
}
    
internal static class ConclusionStatusExtensions
{
    public static Color GetColor(this ConclusionStatus status) =>
        status switch
        {
            ConclusionStatus.Success => Color.Success,
            ConclusionStatus.Fail => Color.Error,
            ConclusionStatus.TimeExceeded => Color.Warning,
            ConclusionStatus.MistakesExceeded => Color.Warning,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
}
