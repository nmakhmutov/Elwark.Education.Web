using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Test;

public sealed record CurrentTest(TestType Type, string Id, DateTime ExpiredAt);
