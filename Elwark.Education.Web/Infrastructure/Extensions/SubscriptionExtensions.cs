using Elwark.Education.Web.Gateways.Models.User;
using MudBlazor;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class SubscriptionExtensions
    {
        public static Color GetColor(this SubscriptionType type) =>
            type switch
            {
                SubscriptionType.Free => Color.Default,
                SubscriptionType.Basic => Color.Tertiary,
                SubscriptionType.Advanced => Color.Warning,
                _ => Color.Default
            };
    }
}