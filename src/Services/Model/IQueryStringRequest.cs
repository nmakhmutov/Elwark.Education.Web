using Education.Web.Services.Api;

namespace Education.Web.Services.Model;

public interface IQueryStringRequest
{
    public QueryString ToQueryString();
}
