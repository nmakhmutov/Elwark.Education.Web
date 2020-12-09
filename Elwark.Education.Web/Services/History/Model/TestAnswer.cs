using System.Collections.Generic;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record TextAnswer(string Text);

    public sealed record SingleAnswer(int Number);

    public sealed record ManyAnswer(IEnumerable<int> Numbers);
}