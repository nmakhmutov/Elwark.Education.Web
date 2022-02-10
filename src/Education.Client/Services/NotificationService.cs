using Education.Client.Gateways.Customer;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;

namespace Education.Client.Services;

internal sealed class NotificationService : IAsyncDisposable
{
    private readonly HubConnection _connection;
    private List<Notification> _notifications;

    public NotificationService(Uri host, IAccessTokenProvider tokenProvider)
    {
        _notifications = new List<Notification>();
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

        _connection.On("Notify", (Notification notification) =>
        {
            _notifications = _notifications.Prepend(notification)
                .Take(5)
                .ToList();

            OnChange();
        });
        
        _connection.Reconnected += _ =>
        {
            _notifications.Clear();
            return Task.CompletedTask;
        };
    }

    public IEnumerable<Notification> Messages =>
        _notifications.AsReadOnly();

    public bool HasNotifications =>
        _notifications.Count > 0;

    public ValueTask DisposeAsync() =>
        _connection.DisposeAsync();

    public async Task StartAsync()
    {
        if (_connection.State == HubConnectionState.Connected)
            return;

        await _connection.StartAsync();
    }

    public async Task MarkAllAsReadAsync()
    {
        _notifications.Clear();

        if (_connection.State == HubConnectionState.Connected)
            await _connection.SendAsync("MarkAllAsRead");
    }

    public event Action OnChange = () => { };
}
