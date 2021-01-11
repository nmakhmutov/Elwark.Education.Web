using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Purchase(DateTime ExpiredAt, bool IsRecurrent);
}