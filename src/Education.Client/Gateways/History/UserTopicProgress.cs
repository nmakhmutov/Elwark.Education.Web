using System;

namespace Education.Client.Gateways.History;

public sealed record UserTopicProgress(ulong PassedTests, TimeSpan TimeSpent);
