using System.Net.Http;
using Education.Client.Gateways.Store.Basket;
using Education.Client.Gateways.Store.Catalog;

namespace Education.Client.Gateways.Store;

internal interface IStoreClient
{
    CatalogClient Catalog { get; }
        
    BasketClient Basket { get; }
}

internal sealed class StoreClient : GatewayClient, IStoreClient
{
    public StoreClient(HttpClient client)
    {
        Catalog = new CatalogClient(client);
        Basket = new BasketClient(client);
    }

    public CatalogClient Catalog { get; }
        
    public BasketClient Basket { get; }
}