using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record CurrentTest(string Id, SubjectType SubjectType, string Title, DateTime ExpiredAt);
}
