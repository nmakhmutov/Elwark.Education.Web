using Education.Web.Client.Features.Customer.Services.Notification;
using Education.Web.Client.Features.Customer.Services.Notification.Model;
using Education.Web.Client.Features.Customer.Services.Notification.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.Customer.Pages.Notifications;

public sealed partial class Page
{
    private readonly List<NotificationModel> _notifications = [];
    private bool _isMoreLoading;
    private NotificationsRequest _request = new(10);

    private ApiResult<PagingTokenModel<NotificationModel>> _result =
        ApiResult<PagingTokenModel<NotificationModel>>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private INotificationService NotificationService { get; init; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["Account_Title"], CustomerUrl.Root),
        new BreadcrumbItem(L["Notifications_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _result = await NotificationService.GetAsync(_request);
        _result.Match(x =>
        {
            _notifications.AddRange(x.Items);
            _request = new NotificationsRequest(20, x.Next);
        });
    }

    private async Task LoadMoreAsync()
    {
        if (_request.Token is null)
            return;

        _isMoreLoading = true;
        (await NotificationService.GetAsync(_request))
            .Match(
                x =>
                {
                    _request = _request with { Token = x.Next };
                    _notifications.AddRange(x.Items);
                },
                e => _result = ApiResult<PagingTokenModel<NotificationModel>>.Fail(e)
            );
        _isMoreLoading = false;
    }

    private async Task MarkAsReadAsync(string id)
    {
        await NotificationService.MarkAsReadAsync(id);
        _notifications.RemoveAll(x => x.Id == id);
    }

    private async Task MarkAllAsReadAsync()
    {
        await NotificationService.MarkAllAsReadAsync();
        _notifications.Clear();
    }
}
