using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Notification.Model;
using Education.Client.Features.Customer.Services.Notification.Request;
using Education.Client.Models;
using Education.Client.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Education.Client.Features.Customer.Services.Notification;

internal sealed class NotificationService : INotificationService
{
    private const int MaxNotifications = 4;

    private readonly CustomerApiClient _api;
    private readonly CustomerHub _hub;
    private readonly List<NotificationMessage> _notifications = [];
    private readonly ISnackbar _snackbar;
    private readonly AuthenticationStateProvider _stateProvider;
    private readonly HashSet<StateChangedSubscription> _subscriptions = [];

    private IDisposable? _subscription;

    public NotificationService(CustomerApiClient api, CustomerHub hub, ISnackbar snackbar,
        AuthenticationStateProvider stateProvider)
    {
        _api = api;
        _hub = hub;
        _snackbar = snackbar;
        _stateProvider = stateProvider;
    }

    public IDisposable NotifyOnChange(EventCallback callback)
    {
        var subscription = new StateChangedSubscription(this, callback);
        _subscriptions.Add(subscription);

        return subscription;
    }

    public Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request) =>
        _api.GetAsync<PagingTokenModel<NotificationModel>>("notifications", request);

    public async Task<ApiResult<Unit>> MarkAllAsReadAsync()
    {
        var result = await _api.DeleteAsync<Unit>("notifications");
        await result.MatchAsync(_ =>
        {
            _notifications.Clear();
            return NotifyChangeSubscribersAsync();
        });

        return result;
    }

    public Task<ApiResult<Unit>> MarkAsReadAsync(string id) =>
        _api.DeleteAsync<Unit>($"notifications/{id}");

    public IReadOnlyCollection<NotificationMessage> LastNotifications =>
        _notifications.AsReadOnly();

    public bool HasNotifications =>
        _notifications.Count > 0;

    public async Task StartAsync()
    {
        if (_subscription is not null)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        var result = await GetAsync(new NotificationsRequest(MaxNotifications));
        result.Match(model =>
        {
            _notifications.Clear();
            _notifications.AddRange(model.Items.Select(m =>
                new NotificationMessage(m.Subject, m.Module, m.Title, m.Message, m.Payload, m.CreatedAt))
            );
        });

        var callback = EventCallback.Factory.Create<NotificationMessage>(this, ReceivedMessage);
        _subscription = _hub.NotifyOnNotification(callback);

        await NotifyChangeSubscribersAsync();
    }

    public void Dispose()
    {
        _subscription?.Dispose();
        _subscriptions.Clear();
    }

    private Task ReceivedMessage(NotificationMessage notification)
    {
        _notifications.Insert(0, notification);

        while (_notifications.Count > MaxNotifications)
            _notifications.Remove(_notifications[^1]);

        var parameters = new Dictionary<string, object>
        {
            [nameof(NotificationBlock.Notification)] = notification
        };

        _snackbar.Add<NotificationBlock>(parameters, Severity.Normal, options => options.HideIcon = true);

        return NotifyChangeSubscribersAsync();
    }

    private Task NotifyChangeSubscribersAsync() =>
        Task.WhenAll(_subscriptions.Select(s => s.NotifyAsync()));

    private void Remove(StateChangedSubscription subscription) =>
        _subscriptions.Remove(subscription);

    private sealed class StateChangedSubscription : IDisposable
    {
        private readonly EventCallback _callback;
        private readonly NotificationService _owner;

        public StateChangedSubscription(NotificationService owner, EventCallback callback)
        {
            _owner = owner;
            _callback = callback;
        }

        public void Dispose() =>
            _owner.Remove(this);

        internal Task NotifyAsync() =>
            _callback.InvokeAsync();
    }
}
