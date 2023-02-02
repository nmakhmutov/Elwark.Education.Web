using Education.Web.Client.Features.Customer.Services.Account.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.Customer.Services.Account;

internal sealed class CustomerService : ICustomerService
{
    private readonly CustomerApiClient _api;

    public CustomerService(CustomerApiClient api) =>
        _api = api;

    public Task<ApiResult<CustomerModel>> GetAsync() =>
        _api.GetAsync<CustomerModel>("customers/me");

    public Task<ApiResult<CustomerModel>> CreateAsync() =>
        _api.PostAsync<CustomerModel>("customers/me");

    public Task<ApiResult<SubjectModel[]>> GetSubjectsAsync() =>
        _api.GetAsync<SubjectModel[]>("customers/me/subjects");
}
