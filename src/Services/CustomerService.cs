using Education.Web.Gateways.Customers;
using Education.Web.Gateways.Customers.Model;
using Education.Web.Hubs.Notification;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Education.Web.Services;

internal sealed class CustomerService : IDisposable
{
    private const int MaxNotifications = 4;
    private readonly ICustomerClient _customerClient;
    private readonly NotificationHub _notificationHub;
    private readonly ISnackbar _snackbar;
    private readonly AuthenticationStateProvider _stateProvider;

    private bool _isInitialized;
    private List<MessageEvent> _notifications = new();

    public CustomerService(ICustomerClient customerClient, NotificationHub notificationHub, ISnackbar snackbar,
        AuthenticationStateProvider stateProvider)
    {
        _customerClient = customerClient;
        _notificationHub = notificationHub;
        _snackbar = snackbar;
        _stateProvider = stateProvider;
    }

    public long Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Image { get; private set; } =
        "https://res.cloudinary.com/elwark/image/upload/v1610430646/People/default_j21xml.png";

    public string Timezone { get; private set; } = "UTC";

    public DayOfWeek WeekStart { get; private set; } = DayOfWeek.Monday;

    public string Language { get; private set; } = "en";

    public bool HasMoreNotifications { get; private set; }

    public IReadOnlyCollection<MessageEvent> Notifications =>
        _notifications.AsReadOnly();

    public bool HasNotifications =>
        _notifications.Count > 0;

    public void Dispose()
    {
        _notificationHub.OnMessageReceived -= ReceivedMessage;
        _notificationHub.OnMarkedAllAsRead -= CleanNotificationsHub;
    }

    public event Action OnChanged = () => { };

    public async Task InitAsync()
    {
        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        if (_isInitialized)
            return;

        var customer = await GetOrCreateCustomerAsync();
        if (customer is null)
            return;

        _isInitialized = true;

        Id = customer.Id;
        Name = customer.Name;
        Image = customer.Image;
        Timezone = customer.Timezone;
        WeekStart = customer.WeekStart;
        Language = customer.Language;

        await _notificationHub.InitAsync();
        _notificationHub.OnMessageReceived += ReceivedMessage;
        _notificationHub.OnMarkedAllAsRead += CleanNotificationsHub;

        var result = await _notificationHub.GetAsync(MaxNotifications, null);
        HasMoreNotifications = !string.IsNullOrEmpty(result.Next);
        _notifications = result.Items
            .Select(x => new MessageEvent(x.Content, x.Subject, x.CreatedAt))
            .ToList();

        OnChanged.Invoke();
    }

    private async Task<CustomerModel?> GetOrCreateCustomerAsync()
    {
        var customer = await _customerClient.GetAsync();
        if (customer.IsSuccess)
            return customer.Data;

        if (customer.IsFailed && customer.Error.Status == 404)
        {
            var result = await _customerClient.CreateAsync();
            if (result.IsSuccess)
                return result.Data;
        }

        return null;
    }

    private void ReceivedMessage(MessageEvent message)
    {
        _notifications = _notifications.Prepend(message).Take(MaxNotifications).ToList();
        _snackbar.Add($@"
<ul>
    <li>{message.Content}</li>
    <li>{message.Subject}</li>
</ul>
");

        OnChanged.Invoke();
    }

    private void CleanNotificationsHub()
    {
        _notifications.Clear();
        OnChanged.Invoke();
    }
}
