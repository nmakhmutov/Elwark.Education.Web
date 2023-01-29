using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.Customer.Model;

namespace Education.Web.Client.Services.Customer;

internal interface ICustomerService
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<SubjectModel[]>> GetSubjectsAsync();
}
