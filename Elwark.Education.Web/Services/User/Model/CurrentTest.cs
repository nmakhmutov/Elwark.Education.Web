using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record CurrentTest(string Id, Subject Subject, string Title, DateTime ExpiredAt);
    
    public sealed record Profile(CurrentTest[] CurrentTests);
}