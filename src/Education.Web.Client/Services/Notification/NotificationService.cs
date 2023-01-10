using System.Text;
using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.Customer;
using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Notification.Model;
using Education.Web.Client.Services.Notification.Request;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Education.Web.Client.Services.Notification;

internal sealed class NotificationService : INotificationService
{
    private const int MaxNotifications = 4;

    private readonly ApiClient _api;
    private readonly CustomerHab _hab;
    private readonly ISnackbar _snackbar;
    private readonly AuthenticationStateProvider _stateProvider;
    private bool _isInitialized;
    private List<NotificationMessage> _lastNotifications = new();

    public NotificationService(ApiClient api, CustomerHab hab, ISnackbar snackbar,
        AuthenticationStateProvider stateProvider)
    {
        _api = api;
        _hab = hab;
        _snackbar = snackbar;
        _stateProvider = stateProvider;
        
        _hab.OnNotificationReceived += ReceivedNotification;
    }

    public Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request) =>
        _api.GetAsync<PagingTokenModel<NotificationModel>>("notifications", request);

    public async Task<ApiResult<Unit>> MarkAllAsReadAsync()
    {
        var result = await _api.DeleteAsync<Unit>("notifications");
        if (result.IsFailed)
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
        _hab.OnNotificationReceived -= ReceivedNotification;

    public event Action OnChanged = () => { };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        var result = await GetAsync(new NotificationsRequest(MaxNotifications));
        if (result.IsSuccess)
            _lastNotifications = result.Value.Items
                .Select(x => new NotificationMessage(x.Subject, x.Title, x.Message, x.CreatedAt))
                .ToList();

        _isInitialized = true;

        OnChanged.Invoke();
    }

    private void ReceivedNotification(NotificationMessage notification)
    {
        _lastNotifications = _lastNotifications
            .Prepend(notification)
            .Take(MaxNotifications)
            .ToList();

        var sb = new StringBuilder("<div class='d-flex align-center justify-space-between'>");
        sb.Append($"<h6 class='mud-typography mud-typography-subtitle1 mr-6'>{notification.Title}</h6>");
        sb.Append($"<p class='mud-typography mud-typography-body2'><i>{notification.Subject}</i></p>");
        sb.Append("</div>");

        if (!string.IsNullOrEmpty(notification.Message))
            sb.Append($"<p class='mud-typography mud-typography-body2'>{notification.Message}</p>");

        _snackbar.Add(sb.ToString());

        OnChanged.Invoke();
    }
}
