namespace Elwark.Education.Web.Gateways
{
    public sealed record Error(string Title, string Type, int Status = 400)
    {
        public static readonly Error NotFound = new("Rpc", "NotFound", 404);

        public static readonly Error Unavailable = new("Unavailable", "Internal", 503);
        
        public static readonly Error Unknown = new("Unknown", "Internal", 500);
    }
}