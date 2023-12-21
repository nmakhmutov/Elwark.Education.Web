using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Notification.Model;
using Education.Client.Features.Customer.Services.Notification.Request;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.Customer.Services.Notification;

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
