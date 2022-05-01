using Blazored.LocalStorage;
using Education.Web.Gateways.Customers;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Services;

public sealed class CustomerService
{
    private const string StorageKey = "cs";
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ICustomerClient _customer;
    private readonly ILocalStorageService _storage;

    public CustomerService(ICustomerClient customer, ILocalStorageService storage,
        AuthenticationStateProvider authenticationStateProvider)
    {
        _customer = customer;
        _storage = storage;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task InitAsync()
    {
        if (await _storage.ContainKeyAsync(StorageKey))
            return;

        var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        await _customer.CreateAsync();
        await _storage.SetItemAsync(StorageKey, Guid.NewGuid());
    }
}
