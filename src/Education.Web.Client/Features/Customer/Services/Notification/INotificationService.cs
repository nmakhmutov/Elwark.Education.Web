using Education.Web.Client.Features.Customer.Services.Notification.Model;
using Education.Web.Client.Features.Customer.Services.Notification.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.Customer.Services.Notification;

public interface INotificationService : IDisposable
{
    public bool HasNotifications { get; }

    public IReadOnlyCollection<NotificationMessage> LastNotifications { get; }

    public event Action OnChanged;

    Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request);

    Task<ApiResult<Unit>> MarkAllAsReadAsync();

    Task<ApiResult<Unit>> MarkAsReadAsync(string id);

    ValueTask InitAsync();
}