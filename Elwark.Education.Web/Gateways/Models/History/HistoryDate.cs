namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryDate(int? Day, int? Month, int Year, Era Era);
    
    public enum Era
    {
        Bc = 0,
        Ad = 1
    }
}