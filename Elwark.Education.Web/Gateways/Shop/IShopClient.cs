using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models.Shop;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Shop
{
    public interface IShopClient
    {
        Task<ApiResponse<Subscription[]>> GetSubscriptions();

        Task<ApiResponse<Subscription[]>> GetSubscriptions(SubjectType subject);
    }
}