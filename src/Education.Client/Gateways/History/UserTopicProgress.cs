using System;

namespace Education.Client.Gateways.History;

public sealed record UserTopicProgress(uint PassedTests, TimeSpan TimeSpent);