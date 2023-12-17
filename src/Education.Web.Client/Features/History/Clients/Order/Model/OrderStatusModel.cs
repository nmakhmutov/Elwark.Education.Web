namespace Education.Web.Client.Features.History.Clients.Order.Model;

public sealed record OrderStatusModel(Guid Id, string Status)
{
    public int Progress =>
        Status switch
        {
            "Created" => 25,
            "StockConfirmed" => 50,
            "Paid" => 75,
            "Shipped" => 100,
            "Cancelled" => 100,
            _ => 0
        };

    public bool IsRejected =>
        Status is "Cancelled";

    public bool IsFinal =>
        Status is "Shipped" or "Cancelled";
}
