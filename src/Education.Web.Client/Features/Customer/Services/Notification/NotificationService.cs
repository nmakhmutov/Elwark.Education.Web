using System.Text;
using Education.Web.Client.Features.Customer.Services.Notification.Model;
using Education.Web.Client.Features.Customer.Services.Notification.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Education.Web.Client.Features.Customer.Services.Notification;

internal sealed class NotificationService : INotificationService
{
    private const int MaxNotifications = 4;

    private readonly CustomerApiClient _api;
    private readonly CustomerHab _hab;
    private readonly ISnackbar _snackbar;
    private readonly AuthenticationStateProvider _stateProvider;
    private bool _isInitialized;
    private List<NotificationMessage> _lastNotifications = new();

    public NotificationService(CustomerApiClient api, CustomerHab hab, ISnackbar snackbar,
        AuthenticationStateProvider stateProvider)
    {
        _api = api;
        _hab = hab;
        _snackbar = snackbar;
        _stateProvider = stateProvider;

        _hab.OnMessageReceived += ReceivedMessage;
    }

    public Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request) =>
        _api.GetAsync<PagingTokenModel<NotificationModel>>("notifications", request);

    public async Task<ApiResult<Unit>> MarkAllAsReadAsync()
    {
        var result = await _api.DeleteAsync<Unit>("notifications");
        if (result.IsError)
            return result;

        _lastNotifications.Clear();
        OnChanged.Invoke();

        return result;
    }

    public Task<ApiResult<Unit>> MarkAsReadAsync(string id) =>
        _api.DeleteAsync<Unit>($"notifications/{id}");

    public IReadOnlyCollection<NotificationMessage> LastNotifications =>
        _lastNotifications.AsReadOnly();

    public bool HasNotifications =>
        _lastNotifications.Count > 0;

    public void Dispose() =>
        _hab.OnMessageReceived -= ReceivedMessage;

    public event Action OnChanged = () =>
    {
    };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        _lastNotifications = (await GetAsync(new NotificationsRequest(MaxNotifications)))
            .Map(x => x.Items.Select(m =>
                new NotificationMessage(m.Subject, m.Module, m.Title, m.Message, m.Payload, m.CreatedAt))
            )
            .UnwrapOr(Enumerable.Empty<NotificationMessage>())
            .ToList();

        _isInitialized = true;

        OnChanged.Invoke();
    }

    private void ReceivedMessage(NotificationMessage notification)
    {
        _lastNotifications = _lastNotifications
            .Prepend(notification)
            .Take(MaxNotifications)
            .ToList();

        var sb = new StringBuilder();
        sb.Append($"<p class='mud-typography mud-typography-caption'>{notification.Subject}</p>");
        sb.Append($"<h6 class='mud-typography mud-typography-subtitle1'>{notification.Title}</h6>");

        if (!string.IsNullOrEmpty(notification.Message))
            sb.Append($"<p class='mud-typography mud-typography-body2'>{notification.Message}</p>");

        _snackbar.Add(sb.ToString());

        OnChanged.Invoke();
    }
}
