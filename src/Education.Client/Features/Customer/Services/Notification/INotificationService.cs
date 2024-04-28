using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Notification.Model;
using Education.Client.Features.Customer.Services.Notification.Request;
using Education.Client.Models;
using Education.Client.Services;
using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.Customer.Services.Notification;

public interface INotificationService : IDisposable, IStartupService
{
    bool HasNotifications { get; }

    IReadOnlyCollection<NotificationMessage> LastNotifications { get; }

    Task<ApiResult<PagingTokenModel<NotificationModel>>> GetAsync(NotificationsRequest request);

    Task<ApiResult<Unit>> MarkAllAsReadAsync();

    Task<ApiResult<Unit>> MarkAsReadAsync(string id);

    IDisposable NotifyOnChange(EventCallback callback);
}
