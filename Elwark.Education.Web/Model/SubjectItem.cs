using System.Collections.Generic;

namespace Elwark.Education.Web.Model
{
    public sealed record SubjectItem(
        Subject Subject,
        string Title,
        string Href,
        IDictionary<string, int> Statistics
    );
}