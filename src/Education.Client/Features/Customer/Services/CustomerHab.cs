using Education.Client.Extensions;
using Education.Client.Features.Customer.Services.Notification.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;

namespace Education.Client.Features.Customer.Services;

internal sealed class CustomerHab : IAsyncDisposable
{
    private readonly HubConnection _connection;
    private readonly HashSet<CustomerStateChangedSubscription> _customerChangedSubscriptions = [];
    private readonly HashSet<NotificationStateChangedSubscription> _notificationSubscriptions = [];
    private readonly AuthenticationStateProvider _stateProvider;

    public CustomerHab(Uri host, IAccessTokenProvider tokenProvider, AuthenticationStateProvider stateProvider)
    {
        _stateProvider = stateProvider;
        _connection = new HubConnectionBuilder()
            .WithUrl(new Uri(host, "/hubs/notification"), options =>
            {
                options.SkipNegotiation = true;
                options.Transports = HttpTransportType.WebSockets;
                options.AccessTokenProvider = async () =>
                {
                    var result = await tokenProvider.RequestAccessToken();
                    return result.TryGetToken(out var token) ? token.Value : null;
                };
            })
            .WithStatefulReconnect()
            .WithServerTimeout(TimeSpan.FromMinutes(10))
            .WithKeepAliveInterval(TimeSpan.FromMinutes(5))
            .WithAutomaticReconnect(RetryPolicy.Instance)
            .Build();
    }

    public ValueTask DisposeAsync()
    {
        _customerChangedSubscriptions.Clear();
        _notificationSubscriptions.Clear();

        return _connection.DisposeAsync();
    }

    public IDisposable NotifyOnCustomerChange(EventCallback<CustomerChangedType> callback)
    {
        var subscription = new CustomerStateChangedSubscription(this, callback);
        _customerChangedSubscriptions.Add(subscription);

        return subscription;
    }

    public IDisposable NotifyOnNotification(EventCallback<NotificationMessage> callback)
    {
        var subscription = new NotificationStateChangedSubscription(this, callback);
        _notificationSubscriptions.Add(subscription);

        return subscription;
    }

    public async ValueTask StartAsync()
    {
        if (_connection.State != HubConnectionState.Disconnected)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (!state.User.IsAuthenticated())
            return;

        _connection.On<CustomerChangedType>("Customers", status => NotifyCustomerChangeSubscribersAsync(status));
        _connection.On<NotificationMessage>("Messages", message => NotifyNotificationSubscribersAsync(message));

        try
        {
            await _connection.StartAsync();
        }
        catch
        {
            // ignored
        }
    }

    private Task NotifyCustomerChangeSubscribersAsync(CustomerChangedType status) =>
        Task.WhenAll(_customerChangedSubscriptions.Select(s => s.NotifyAsync(status)));

    private Task NotifyNotificationSubscribersAsync(NotificationMessage message) =>
        Task.WhenAll(_notificationSubscriptions.Select(s => s.NotifyAsync(message)));

    private sealed class RetryPolicy : IRetryPolicy
    {
        public static readonly RetryPolicy Instance = new();

        private RetryPolicy()
        {
        }

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

    private sealed class CustomerStateChangedSubscription : IDisposable
    {
        private readonly EventCallback<CustomerChangedType> _callback;
        private readonly CustomerHab _owner;

        public CustomerStateChangedSubscription(CustomerHab owner, EventCallback<CustomerChangedType> callback)
        {
            _owner = owner;
            _callback = callback;
        }

        public void Dispose() =>
            _owner._customerChangedSubscriptions.Remove(this);

        public Task NotifyAsync(CustomerChangedType type) =>
            _callback.InvokeAsync(type);
    }

    private sealed class NotificationStateChangedSubscription : IDisposable
    {
        private readonly EventCallback<NotificationMessage> _callback;
        private readonly CustomerHab _owner;

        public NotificationStateChangedSubscription(CustomerHab owner, EventCallback<NotificationMessage> callback)
        {
            _owner = owner;
            _callback = callback;
        }

        public void Dispose() =>
            _owner._notificationSubscriptions.Remove(this);

        public Task NotifyAsync(NotificationMessage message) =>
            _callback.InvokeAsync(message);
    }
}
