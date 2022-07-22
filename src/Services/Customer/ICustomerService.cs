using Education.Web.Services.Api;
using Education.Web.Services.Customer.Model;

namespace Education.Web.Services.Customer;

internal interface ICustomerService
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();
}