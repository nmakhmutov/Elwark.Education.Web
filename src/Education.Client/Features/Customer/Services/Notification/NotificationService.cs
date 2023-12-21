using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Notification.Model;
using Education.Client.Features.Customer.Services.Notification.Request;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Education.Client.Features.Customer.Services.Notification;

internal sealed class NotificationService : INotificationService
{
    private const int MaxNotifications = 4;

    private readonly CustomerApiClient _api;
    private readonly CustomerHab _hab;
    private readonly ISnackbar _snackbar;
    private readonly AuthenticationStateProvider _stateProvider;
    private readonly HashSet<StateChangedSubscription> _subscriptions = [];
    private bool _isInitialized;
    private List<NotificationMessage> _notifications = [];
    private IDisposable? _subscription;

    public NotificationService(CustomerApiClient api, CustomerHab hab, ISnackbar snackbar,
        AuthenticationStateProvider stateProvider)
    {
        _api = api;
        _hab = hab;
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
        if (result.IsError)
            return result;

        _notifications.Clear();
        await NotifyChangeSubscribersAsync();

        return result;
    }

    public Task<ApiResult<Unit>> MarkAsReadAsync(string id) =>
        _api.DeleteAsync<Unit>($"notifications/{id}");

    public IReadOnlyCollection<NotificationMessage> LastNotifications =>
        _notifications.AsReadOnly();

    public bool HasNotifications =>
        _notifications.Count > 0;

    public void Dispose() =>
        _subscription?.Dispose();

    public async Task StartAsync()
    {
        if (_isInitialized)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        var callback = EventCallback.Factory.Create<NotificationMessage>(this, ReceivedMessage);
        _subscription = _hab.NotifyOnNotification(callback);

        _notifications = (await GetAsync(new NotificationsRequest(MaxNotifications)))
            .Map(x => x.Items.Select(m =>
                new NotificationMessage(m.Subject, m.Module, m.Title, m.Message, m.Payload, m.CreatedAt))
            )
            .UnwrapOr(Enumerable.Empty<NotificationMessage>())
            .ToList();

        _isInitialized = true;

        await NotifyChangeSubscribersAsync();
    }

    private Task ReceivedMessage(NotificationMessage notification)
    {
        _notifications = _notifications
            .Prepend(notification)
            .Take(MaxNotifications)
            .ToList();

        var message = $"""
                       <h6 class='mud-typography mud-typography-subtitle1'>{notification.Title}</h6>
                       <p class='mud-typography mud-typography-body2'>{notification.Message}</p>
                       """;

        _snackbar.Add(message);

        return NotifyChangeSubscribersAsync();
    }

    private Task NotifyChangeSubscribersAsync() =>
        Task.WhenAll(_subscriptions.Select(s => s.NotifyAsync()));

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
            _owner._subscriptions.Remove(this);

        public Task NotifyAsync() =>
            _callback.InvokeAsync();
    }
}
