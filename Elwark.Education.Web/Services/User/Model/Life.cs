using System;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record Life(int Points, DateTime? NextIncreaseAt);
}