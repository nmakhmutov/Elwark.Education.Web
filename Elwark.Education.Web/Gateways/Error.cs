using System.Linq;

namespace Elwark.Education.Web.Gateways
{
    public sealed record Error(string Title, string Type, int Status = 400)
    {
        public bool OneOf(params Error[] errors) =>
            errors.Any(error => Equals(this, error));

        public static readonly Error NotFound = new("NotFound", "Internal", 404);

        public static readonly Error TestExpired = new("TestExpired", "Rpc", 412);

        public static readonly Error Unavailable = new("Unavailable", "Internal", 503);

        public static readonly Error Unknown = new("Unknown", "Internal", 500);

        public static readonly Error Unauthorized = new("Unauthorized", "Internal", 401);
    }
}