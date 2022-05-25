using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;

namespace Education.Web.Hubs.Notification;

internal sealed class NotificationHub : IAsyncDisposable
{
    private readonly HubConnection _connection;
    private readonly AuthenticationStateProvider _stateProvider;
    private List<NotificationModel> _messages;

    public NotificationHub(Uri host, IAccessTokenProvider tokenProvider, AuthenticationStateProvider stateProvider)
    {
        _stateProvider = stateProvider;
        _messages = new List<NotificationModel>();
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

        _connection.On("Notify", (NotificationModel notification) =>
        {
            _messages = _messages.Prepend(notification).Take(5).ToList();
            OnChange.Invoke();
        });

        _connection.Reconnected += _ =>
        {
            _messages.Clear();
            return Task.CompletedTask;
        };
    }

    public IReadOnlyCollection<NotificationModel> Messages =>
        _messages.AsReadOnly();

    public bool HasMessages =>
        _messages.Count > 0;

    public ValueTask DisposeAsync() =>
        _connection.DisposeAsync();

    public event Action OnChange = () => { };

    public async Task StartAsync()
    {
        if (_connection.State == HubConnectionState.Connected)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated ?? false)
            await _connection.StartAsync();
    }

    public async Task MarkAllAsReadAsync()
    {
        _messages.Clear();

        if (_connection.State == HubConnectionState.Connected)
            await _connection.SendAsync("MarkAllAsRead");
    }
}
