namespace Education.Web.Client.Features.History.Services.Order.Model;

public sealed record OrderStatusModel(int Code, string Name)
{
    public int Progress =>
        Name switch
        {
            "Creating" => 10,
            "Created" => 30,
            "StockConfirmed" => 60,
            "Paid" => 90,
            "Shipped" => 100,
            "Cancelled" => 100,
            _ => 0
        };

    public bool IsRejected =>
        Name is "Cancelled";

    public bool IsFinal =>
        Name is "Shipped" or "Cancelled";
}
