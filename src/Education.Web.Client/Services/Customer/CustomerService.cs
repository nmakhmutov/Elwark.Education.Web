using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.Customer.Model;

namespace Education.Web.Client.Services.Customer;

internal sealed class CustomerService : ICustomerService
{
    private readonly ApiClient _api;

    public CustomerService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<CustomerModel>> GetAsync() =>
        _api.GetAsync<CustomerModel>("customers/me");

    public Task<ApiResult<CustomerModel>> CreateAsync() =>
        _api.PostAsync<CustomerModel>("customers/me");

    public Task<ApiResult<SubjectModel[]>> GetSubjectsAsync() =>
        _api.GetAsync<SubjectModel[]>("customers/me/subjects");
}
