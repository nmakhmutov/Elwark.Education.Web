using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;

namespace Education.Web.Hubs.Notification;

internal sealed class NotificationHub : IAsyncDisposable
{
    private readonly HubConnection _connection;
    private readonly AuthenticationStateProvider _stateProvider;

    public NotificationHub(Uri host, IAccessTokenProvider tokenProvider, AuthenticationStateProvider stateProvider)
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
            .WithAutomaticReconnect()
            .Build();

        _connection.On("Notifications", (NotificationMessage notification) => OnNotificationReceived.Invoke(notification));
    }

    public ValueTask DisposeAsync() =>
        _connection.DisposeAsync();

    public event Action<NotificationMessage> OnNotificationReceived = _ => { };

    public async Task InitAsync()
    {
        if (_connection.State == HubConnectionState.Connected)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated ?? false)
            await _connection.StartAsync();
    }
}
