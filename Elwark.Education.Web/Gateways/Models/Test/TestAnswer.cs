using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.Test
{
    public abstract record TestAnswer;

    public sealed record TextAnswer(string Text) : TestAnswer;

    public sealed record SingleAnswer(int Number) : TestAnswer;

    public sealed record ManyAnswer(IEnumerable<int> Numbers) : TestAnswer;
}
