using MudBlazor;

namespace Education.Web.Client.Services.Model.Test;

public enum ConclusionStatus
{
    Succeeded = 0,
    Failed = 1,
    TimeExceeded = 2,
    MistakesExceeded = 3
}

internal static class ConclusionStatusExtensions
{
    public static Color GetColor(this ConclusionStatus status) =>
        status switch
        {
            ConclusionStatus.Succeeded => Color.Success,
            ConclusionStatus.Failed => Color.Error,
            ConclusionStatus.TimeExceeded => Color.Warning,
            ConclusionStatus.MistakesExceeded => Color.Warning,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
}
