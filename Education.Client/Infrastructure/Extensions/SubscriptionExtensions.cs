using Education.Client.Gateways.Models.User;
using MudBlazor;

namespace Education.Client.Infrastructure.Extensions
{
    public static class SubscriptionExtensions
    {
        public static Color GetColor(this SubscriptionType type) =>
            type switch
            {
                SubscriptionType.Free => Color.Default,
                SubscriptionType.Basic => Color.Secondary,
                SubscriptionType.Advanced => Color.Warning,
                _ => Color.Default
            };
    }
}
