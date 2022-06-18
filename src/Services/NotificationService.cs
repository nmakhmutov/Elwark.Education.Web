using System.Text;
using Education.Web.Gateways.Customers;
using Education.Web.Gateways.Customers.Model;
using Education.Web.Gateways.Customers.Requests;
using Education.Web.Hubs.Notification;
using MudBlazor;

namespace Education.Web.Services;

internal sealed class NotificationService : IDisposable
{
    private const int MaxNotifications = 4;

    private readonly ICustomerClient _customer;
    private readonly NotificationHub _hub;
    private readonly ISnackbar _snackbar;

    private bool _isInitialized;
    private List<NotificationMessage> _notifications = new();

    public NotificationService(ICustomerClient customer, NotificationHub hub, ISnackbar snackbar)
    {
        _customer = customer;
        _hub = hub;
        _snackbar = snackbar;
    }

    public IReadOnlyCollection<NotificationMessage> Notifications =>
        _notifications.AsReadOnly();

    public bool HasNotifications =>
        _notifications.Count > 0;

    public void Dispose() =>
        _hub.OnNotificationReceived -= ReceivedNotification;

    public event Action OnChanged = () => { };

    public async Task InitAsync()
    {
        if (_isInitialized)
            return;

        await _hub.InitAsync();
        _hub.OnNotificationReceived += ReceivedNotification;

        var result = await _customer.GetAsync(new NotificationsRequest(null, MaxNotifications));
        if (result.IsSuccess)
        {
            _notifications = result.Data.Items
                .Select(x => new NotificationMessage(x.Subject, x.Title, x.Message, x.CreatedAt))
                .ToList();

            _isInitialized = true;
            OnChanged.Invoke();
        }
    }

    public void Update(IEnumerable<NotificationModel> notifications)
    {
        _notifications = notifications
            .Take(MaxNotifications)
            .Select(x => new NotificationMessage(x.Subject, x.Title, x.Message, x.CreatedAt))
            .ToList();

        OnChanged.Invoke();
    }

    public async Task MarkAsReadAsync()
    {
        await _customer.MarkAllNotificationsAsReadAsync();

        _notifications.Clear();
        OnChanged.Invoke();
    }

    private void ReceivedNotification(NotificationMessage notification)
    {
        _notifications = _notifications.Prepend(notification).Take(MaxNotifications).ToList();
        
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
