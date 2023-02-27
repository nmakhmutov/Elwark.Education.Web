using Education.Web.Client.Features.Customer.Services.Notification.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;

namespace Education.Web.Client.Features.Customer.Services;

internal sealed class CustomerHab : IAsyncDisposable
{
    private readonly HubConnection _connection;
    private readonly AuthenticationStateProvider _stateProvider;

    public CustomerHab(Uri host, IAccessTokenProvider tokenProvider, AuthenticationStateProvider stateProvider)
    {
        _stateProvider = stateProvider;
        _connection = new HubConnectionBuilder()
            .WithUrl(new Uri(host, "/hubs/notification"), options =>
            {
                options.AccessTokenProvider = async () =>
                {
                    var result = await tokenProvider.RequestAccessToken();
                    return result.TryGetToken(out var token) ? token.Value : null;
                };
            })
            .WithAutomaticReconnect(new RetryPolicy())
            .Build();

        _connection.On<NotificationMessage>("Notifications", message => OnNotificationReceived.Invoke(message));
    }

    public ValueTask DisposeAsync() =>
        _connection.DisposeAsync();

    public event Action<NotificationMessage> OnNotificationReceived = _ =>
    {
    };

    public async ValueTask InitAsync()
    {
        if (_connection.State != HubConnectionState.Disconnected)
            return;

        try
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity?.IsAuthenticated ?? false)
                await _connection.StartAsync();
        }
        catch
        {
            // ignored
        }
    }

    private sealed class RetryPolicy : IRetryPolicy
    {
        public TimeSpan? NextRetryDelay(RetryContext retryContext) =>
            retryContext.PreviousRetryCount switch
            {
                0 => TimeSpan.Zero,
                1 => TimeSpan.FromSeconds(2),
                2 => TimeSpan.FromSeconds(10),
                3 => TimeSpan.FromSeconds(30),
                4 => TimeSpan.FromMinutes(1),
                _ => TimeSpan.FromMinutes(5)
            };
    }
}
