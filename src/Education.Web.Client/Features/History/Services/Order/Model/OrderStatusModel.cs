namespace Education.Web.Client.Features.History.Services.Order.Model;

public sealed record OrderStatusModel(int Code, string Name)
{
    public int Progress =>
        Name switch
        {
            "Creating" => 10,
            "Created" => 30,
            "StockConfirmed" => 60,
            "PaymentConfirmed" => 90,
            _ => 100
        };

    public bool IsRejected =>
        Name is "StockRejected" or "PaymentRejected" or "ShippedRejected";

    public bool IsFinal =>
        Name is "ShippedConfirmed" || IsRejected;
}
