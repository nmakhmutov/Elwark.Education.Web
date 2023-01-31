using Education.Http;
using Education.Web.Client.Services.Customer.Notification.Model;
using Education.Web.Client.Services.Customer.Notification.Request;
using Education.Web.Client.Services.Model;

namespace Education.Web.Client.Services.Customer.Notification;

public interface INotificationService : IDisposable
{
    public event Action OnChanged;

    public bool HasNotifications { get; }

    public IReadOnlyCollection<NotificationMessage> LastNotifications { get; }

    Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request);

    Task<ApiResult<Unit>> MarkAllAsReadAsync();

    Task<ApiResult<Unit>> MarkAsReadAsync(string id);

    ValueTask InitAsync();
}
