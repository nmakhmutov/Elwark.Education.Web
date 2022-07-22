using Education.Web.Services.Api;
using Education.Web.Services.Model;
using Education.Web.Services.Notification.Model;
using Education.Web.Services.Notification.Request;

namespace Education.Web.Services.Notification;

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
