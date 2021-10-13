using System;
using MudBlazor;

namespace Education.Client.Gateways.Models.Test;

public enum TestType
{
    Easy = 0,
    Hard = 1,
    Mixed = 2
}
    
internal static class TestTypeExtensions
{
    public static Color GetColor(this TestType type) =>
        type switch
        {
            TestType.Easy => Color.Primary,
            TestType.Hard => Color.Secondary,
            TestType.Mixed => Color.Tertiary,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}