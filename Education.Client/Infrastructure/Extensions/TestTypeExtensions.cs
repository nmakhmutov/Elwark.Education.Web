using System;
using Education.Client.Gateways.Models.Test;
using MudBlazor;

namespace Education.Client.Infrastructure.Extensions
{
    public static class TestTypeExtensions
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
}
