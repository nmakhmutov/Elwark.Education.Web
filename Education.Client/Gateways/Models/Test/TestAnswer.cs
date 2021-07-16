using System.Collections.Generic;

namespace Education.Client.Gateways.Models.Test
{
    public abstract record TestAnswer;

    public sealed record TextAnswer(string Text) : TestAnswer;

    public sealed record OneAnswer(int Number) : TestAnswer;

    public sealed record ManyAnswer(IEnumerable<int> Numbers) : TestAnswer;
}
