using Education.Web.Client.Extensions;
using Education.Web.Client.Features.Customer.Services;
using Education.Web.Client.Features.Customer.Services.Account;
using Education.Web.Client.Features.Customer.Services.Account.Model;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Client.Shared.Customer;

internal sealed class CustomerStateProvider : IDisposable
{
    private readonly ICustomerService _customerService;
    private readonly CustomerHab _hab;
    private readonly AuthenticationStateProvider _provider;
    private bool _isInitialized;
    private CustomerState _state;

    public CustomerStateProvider(ICustomerService customerService, AuthenticationStateProvider provider,
        CustomerHab hab)
    {
        _customerService = customerService;
        _provider = provider;
        _hab = hab;
        _state = CustomerState.Anonymous;
    }

    public void Dispose() =>
        _hab.OnCustomerChanged -= OnCustomerChanged;

    public event Action<CustomerState> OnChanged = _ =>
    {
    };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        var state = await _provider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        _hab.OnCustomerChanged += OnCustomerChanged;

        await UpdateCustomer();

        _isInitialized = true;
    }

    private async void OnCustomerChanged(CustomerChangedType status)
    {
        switch (status)
        {
            case CustomerChangedType.Created:
                return;

            case CustomerChangedType.Updated:
                await UpdateCustomer();
                break;

            case CustomerChangedType.Deleted:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }
    }

    private async Task UpdateCustomer()
    {
        var customer = await GetOrCreateCustomerAsync();
        if (customer is null)
            return;

        _state = CustomerState.Map(customer);

        OnChanged.Invoke(_state);
    }

    private async Task<CustomerModel?> GetOrCreateCustomerAsync()
    {
        var customer = await _customerService.GetAsync();
        if (customer.IsSuccess)
            return customer.Unwrap();

        if (!customer.UnwrapError().IsUserNotFound())
            return null;

        var result = await _customerService.CreateAsync();
        return result.IsSuccess ? result.Unwrap() : null;
    }
}
