using Education.Web.Gateways;
using Education.Web.Gateways.Customers;
using Education.Web.Gateways.Customers.Model;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Components.Customer;

internal sealed class CustomerStateProvider
{
    private readonly ICustomerClient _customerClient;
    private readonly AuthenticationStateProvider _stateProvider;
    private bool _isInitialized;
    private CustomerState _state;

    public CustomerStateProvider(ICustomerClient customerClient, AuthenticationStateProvider stateProvider)
    {
        _customerClient = customerClient;
        _stateProvider = stateProvider;
        _state = CustomerState.Anonymous;
    }

    public event Action<CustomerState> StateChanged = _ => { };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        var customer = await GetOrCreateCustomerAsync();
        if (customer is null)
            return;

        _state = CustomerState.Authenticated(
            customer.FullName,
            customer.Image,
            customer.TimeZone,
            customer.WeekStart,
            customer.Language,
            customer.DateFormat,
            customer.TimeFormat
        );

        _isInitialized = true;
        StateChanged.Invoke(_state);
    }

    public CustomerState GetCurrentState() =>
        _state;

    private async Task<CustomerModel?> GetOrCreateCustomerAsync()
    {
        var customer = await _customerClient.GetAsync();
        if (customer.IsSuccess)
            return customer.Data;

        if (!customer.Error.IsUserNotFound())
            return null;

        var result = await _customerClient.CreateAsync();
        return result.IsSuccess ? result.Data : null;
    }
}
