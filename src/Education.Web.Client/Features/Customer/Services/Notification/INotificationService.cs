using Education.Web.Client.Clients;
using Education.Web.Client.Features.Customer.Services.Notification.Model;
using Education.Web.Client.Features.Customer.Services.Notification.Request;
using Education.Web.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Features.Customer.Services.Notification;

public interface INotificationService : IDisposable
{
    public bool HasNotifications { get; }

    public IReadOnlyCollection<NotificationMessage> LastNotifications { get; }

    Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request);

    Task<ApiResult<Unit>> MarkAllAsReadAsync();

    Task<ApiResult<Unit>> MarkAsReadAsync(string id);

    public IDisposable NotifyOnChange(EventCallback callback);

    Task StartAsync();
}
