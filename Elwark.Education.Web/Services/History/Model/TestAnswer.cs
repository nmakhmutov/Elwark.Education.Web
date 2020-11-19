using System.Collections.Generic;

namespace Elwark.Education.Web.Services.History.Model
{
    public abstract record TestAnswer;

    public sealed record SingleAnswer(string Answer) : TestAnswer;

    public sealed record ManyAnswer(IEnumerable<string> Answers) : TestAnswer;
}