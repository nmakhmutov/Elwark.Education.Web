namespace Education.Web.Client.Features.History.Services.Order.Model;

public sealed record OrderStatusModel(Guid Id, string Status)
{
    public int Progress =>
        Status switch
        {
            "Created" => 0,
            "StockConfirmed" => 33,
            "Paid" => 66,
            "Shipped" => 100,
            "Cancelled" => 100,
            _ => 0
        };

    public bool IsRejected =>
        Status is "Cancelled";

    public bool IsFinal =>
        Status is "Shipped" or "Cancelled";
}
