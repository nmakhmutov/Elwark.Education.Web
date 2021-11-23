using System;

namespace Education.Client.Gateways.History.Me;

public sealed record Activity(
    DateTime Date,
    uint Total,
    uint EasyTests,
    uint HardTests,
    uint MixedTests,
    uint EventGuessers
);
